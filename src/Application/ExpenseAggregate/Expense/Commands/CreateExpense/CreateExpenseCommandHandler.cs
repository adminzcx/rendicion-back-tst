
using Ardalis.GuardClauses;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.AdminAggregate.ExpenseStops.Specifications;
using Prome.Viaticos.Server.Application.AdminAggregate.KmPriceConfigurations.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Specifications;
using Prome.Viaticos.Server.Application.ExpenseAggregate.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.CuentaCorrienteAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate;
using Prome.Viaticos.Server.Domain.Entities.ExpenseFormAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.ExpenseAggregate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.CreateExpense
{

    public class CreateExpenseCommandHandler : CommandHandler<CreateExpenseCommand>
    {
        private readonly IConfiguration _configuration;
        private readonly IDateTime _dateTimeService;
        private readonly IFileService _fileService;
        private readonly IMapService _googleMapService;

        public CreateExpenseCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IConfiguration configuration,
            IMapper mapper,
            IDateTime dateTimeService,
            IFileService fileService,
            IMapService googleMapService)
            : base(unitOfWork, mapper)
        {
            _configuration = configuration;
            _dateTimeService = dateTimeService;
            _fileService = fileService;
            _googleMapService = googleMapService;
        }

        public override async Task<Unit> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var reason = await this.GetReasonAsync(request.ReasonId);
            var concept = await this.GetConceptAsync(request.ConceptId);

            var entity = _mapper.Map<Domain.Entities.ExpenseAggregate.Expense>(request);
            entity.User = currentUser;
            entity.Reason = reason;
            entity.Concept = concept;
            entity.MobilityAmount = request.MobilityAmount;
            entity.Status = await FindById<ExpenseStatus>((int)ExpenseStatusEnum.Pendiente);
            entity.Segment = await this.GetSegmentAsync(request.SegmentId);
            entity.Source = await this.GetSourceAsync(request.SourceId);
            entity.TechnicalVisit = await this.GetTechnicalVisitAsync(request.TechnicalVisitId);
            entity.DocumentAttached = this.UploadFile(request.URLFile, request.DocumentAttached);
            entity.ExpenseForm = await this.GetExpenseFormAsync(request.ExpenseFormId);
            entity.Campaign = await this.GetCampaignAsync(request.CampaignId);
            entity.AddUsers(await this.GetUsersAsync(request.Users));
            #region GoogleMap

            var map = await this.GetCurrentPositionAsync(request, entity.Source, currentUser.Id);
            if (map != null)
            {
                entity.SourceLatitude = map.SourceLatitude;
                entity.SourceLongitude = map.SourceLongitude;
                entity.KM = map.Km;
                entity.PriceByKM = entity.GetPriceByKm(await GetKmConfigurationsByKmAsync(), _dateTimeService.Now);
                entity.Amount = this.CalculatePriceOfPosition(map, entity.PriceByKM);
                entity.ImageMAP = this.SaveImageMap(map);
            }
            #endregion


            #region Advices
            var expenseStopList = await this.GetExpenseStopsAsync(request.ConceptId);
            var expenseList = await this.GetExpensesAsync(entity.User.Id, entity.ExpenseDate, entity.Id);
            entity.GenerateAdvices(expenseStopList, expenseList);
            #endregion

            if (request.YPFRuta && request.ReasonId != 1 &&
                (request.ConceptId == 12 || request.ConceptId == 13 || request.ConceptId == 18 || request.ConceptId == 19
                 || request.ConceptId == 24 || request.ConceptId == 25 || request.ConceptId == 30 || request.ConceptId == 31
                  || request.ConceptId == 36 || request.ConceptId == 37 || request.ConceptId == 42 || request.ConceptId == 43
                   || request.ConceptId == 48 || request.ConceptId == 49 || request.ConceptId == 54 || request.ConceptId == 55))
            {

                var ctaCte = new CuentasCorrientes
                {
                    Fecha = entity.ExpenseDate,
                    Legajo = Convert.ToInt32(currentUser.EmployeeRecord),
                    Monto = (decimal)entity.Amount,
                    Observaciones = entity.Description,
                    Reason = entity.Reason,
                    Km = entity.KM
                };

                await _unitOfWork.Repository<CuentasCorrientes>().AddAsync(ctaCte);
            }
            else
            {
                await _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Expense>().AddAsync(entity);
            }

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        #region Advices
        private async Task<List<ExpenseStops>> GetExpenseStopsAsync(int conceptId)
        {
            return (List<ExpenseStops>)await _unitOfWork
                .Repository<ExpenseStops>()
                .ListAsync(new ExpenseStopByConceptSpecification(conceptId));
        }

        private async Task<List<Domain.Entities.ExpenseAggregate.Expense>> GetExpensesAsync(long userId, DateTime date, long expenseId)
        {
            return (List<Domain.Entities.ExpenseAggregate.Expense>)await _unitOfWork
                .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                .ListAsync(new ExpenseByConceptAndUserSpecification(userId, date, expenseId));
        }
        #endregion


        private async Task<User> GetCurrentUserAsync(string email)
        {
            var users = await _unitOfWork
                 .Repository<User>()
                 .ListAsync(new ByEmployeeEmailSpecification(email));

            Guard.Against.Null(users, nameof(email));
            Guard.Against.IsValidUser(users);

            return users.First();
        }

        private async Task<Domain.Entities.ExpenseAggregate.Reason> GetReasonAsync(int reasonId)
        {
            var result = await FindById<Domain.Entities.ExpenseAggregate.Reason>(reasonId);
            Guard.Against.Null(result, nameof(reasonId));
            return result;
        }
        private async Task<Domain.Entities.ExpenseAggregate.Campaign> GetCampaignAsync(int campaignId)
        {
            if (campaignId > 0)
            {
                return await FindById<Domain.Entities.ExpenseAggregate.Campaign>(campaignId);
            }
            else return null;
        }

        private async Task<Domain.Entities.ExpenseAggregate.Concept> GetConceptAsync(int conceptId)
        {
            var result = await FindById<Domain.Entities.ExpenseAggregate.Concept>(conceptId);
            Guard.Against.Null(result, nameof(conceptId));
            return result;
        }
        private async Task<Domain.Entities.ExpenseAggregate.Segment> GetSegmentAsync(int? segmentId)
        {
            if (segmentId > 0)
            {
                return await FindById<Domain.Entities.ExpenseAggregate.Segment>((int)segmentId);
            }
            else return null;
        }
        private async Task<ExpenseForm> GetExpenseFormAsync(int? expenseFormId)
        {
            if (expenseFormId > 0)
            {
                return await FindById<ExpenseForm>((int)expenseFormId);
            }
            else return null;
        }

        private async Task<Domain.Entities.ExpenseAggregate.Source> GetSourceAsync(int? sourceId)
        {
            if (sourceId > 0)
            {
                return await FindById<Domain.Entities.ExpenseAggregate.Source>((int)sourceId);
            }
            else return null;
        }
        private async Task<Domain.Entities.ExpenseAggregate.TechnicalVisit> GetTechnicalVisitAsync(int? technicalVisitId)
        {
            if (technicalVisitId > 0)
            {
                return await FindById<Domain.Entities.ExpenseAggregate.TechnicalVisit>((int)technicalVisitId);
            }
            else return null;
        }

        private async Task<List<ExpenseUser>> GetUsersAsync(ICollection<ExpenseUserDto> users)
        {

            if (users != null)
            {
                var expenseUsers = new List<ExpenseUser>();
                foreach (var user in users)
                {
                    var userExpense = await FindById<User>(user.Id);
                    Guard.Against.Null(userExpense, nameof(user.Id));

                    var expenseUserEntity = new ExpenseUser
                    {
                        User = userExpense,
                        ExpenseDate = _dateTimeService.Now
                    };
                    expenseUsers.Add(expenseUserEntity);
                }
                return expenseUsers;
            }
            else return null;
        }
        private string UploadFile(string uRlFile, string documentAttached)
        {
            if (!string.IsNullOrEmpty(uRlFile) && !string.IsNullOrEmpty(documentAttached))
            {
                var customDocumentAttached = _dateTimeService.NowToCustomString + "-" + documentAttached;
                _fileService.UploadFile(FolderPathEnum.Expense, uRlFile, customDocumentAttached);

                return customDocumentAttached;
            }
            else return string.Empty;
        }

        private async Task<List<KmPriceConfiguration>> GetKmConfigurationsByKmAsync()
        {
            return (List<KmPriceConfiguration>)await _unitOfWork
                  .Repository<KmPriceConfiguration>()
                  .ListAsync(new KmPriceConfigurationActiveSpecification());

        }
        private decimal? CalculatePriceOfPosition(Geolocation map, decimal? price)
        {
            return map.Km * price;
        }
        private string SaveImageMap(Geolocation map)
        {
            if (map.Map != null)
            {
                var googleMapFileName = _dateTimeService.NowToCustomString + "-map.png";
                _fileService.SaveFile(FolderPathEnum.Map, map.Map, googleMapFileName);
                return googleMapFileName;
            }
            else return string.Empty;
        }
        private async Task<Geolocation> GetCurrentPositionAsync(CreateExpenseCommand request, Domain.Entities.ExpenseAggregate.Source source, long userId)
        {
            if (source == null) { return null; }

            if (request.Device.ToLower() == nameof(ExpenseSourceEnum.Web).ToLower() && string.IsNullOrEmpty(request.GoogleURL)) return null;
            if (request.Device == nameof(ExpenseSourceEnum.Mobile) && (request.Latitude == 0 || request.Latitude == 0)) return null;

            string path = _configuration["MySettings:GoogleMapPath"];
            ExpenseFolderGuard.PathFolderValid(path);

            Map model = new Map();
            model.Token = _configuration["MySettings:TokenGoogleMap"];
            model.Url = request.GoogleURL;
            model.Latitude = Convert.ToDouble((request.Latitude == null) ? request.GoogleURL.Split('@')[1].Split(',')[0].Replace('.', ',') : "0");
            model.Longitude = Convert.ToDouble((request.Longitude == null) ? request.GoogleURL.Split('@')[1].Split(',')[1].Replace('.', ',') : "0");

            var dataUser = await this.GetCurrentUserAsync(request.Email);

            if (source.Id == (int)SourceEnum.Sucursal)
            {
                model.SourceLatitude = Convert.ToDouble((CultureInfo.InstalledUICulture.Name == "en-US") ? dataUser.Branch.Latitud.Replace(',', '.') : dataUser.Branch.Latitud);
                model.SourceLongitude = Convert.ToDouble((CultureInfo.InstalledUICulture.Name == "en-US") ? dataUser.Branch.Longitud.Replace(',', '.') : dataUser.Branch.Longitud);
            }
            if (source.Id == (int)SourceEnum.VisitaAnterior)
            {
                var lastVisit = await this.GetLatestVisit(userId);

                if (lastVisit != null)
                {
                    model.SourceLatitude = (CultureInfo.InstalledUICulture.Name == "en-US")
                        ? Convert.ToDouble(lastVisit.Latitude.ToString().Replace(',', '.'))
                        : Convert.ToDouble(lastVisit.Latitude);
                    model.SourceLongitude = (CultureInfo.InstalledUICulture.Name == "en-US")
                        ? Convert.ToDouble(lastVisit.Longitude.ToString().Replace(',', '.'))
                        : Convert.ToDouble(lastVisit.Longitude);
                }
                else
                {
                    model.SourceLatitude = Convert.ToDouble((CultureInfo.InstalledUICulture.Name == "en-US") ? dataUser.Branch.Latitud.Replace(',', '.') : dataUser.Branch.Latitud);
                    model.SourceLongitude = Convert.ToDouble((CultureInfo.InstalledUICulture.Name == "en-US") ? dataUser.Branch.Longitud.Replace(',', '.') : dataUser.Branch.Longitud);
                }
            }

            var currentPosition = _googleMapService.GetCurrentPosition(model);

            var listVisits = await this.GetVisits(userId);

            if (listVisits != null)
            {
                foreach (var visit in listVisits)
                {
                    if (source.Id == (int)SourceEnum.VisitaAnterior)
                    {
                        currentPosition.Km += (decimal)visit.KM;

                        model.SourceLatitude = Convert.ToDouble(visit.Latitude);
                        model.SourceLongitude = Convert.ToDouble(visit.Longitude);

                        model.Latitude = Convert.ToDouble(dataUser.Branch.Latitud);
                        model.Longitude = Convert.ToDouble(dataUser.Branch.Longitud);

                        var positionRemove = _googleMapService.GetCurrentPosition(model);

                        currentPosition.Km -= positionRemove.Km;
                    }
                    else { break; }

                    if (visit.Source.Id == (int)SourceEnum.Sucursal) { currentPosition.Km += (decimal)visit.KM; break; }
                }
            }

            model.SourceLatitude = Convert.ToDouble((request.Latitude == null) ? request.GoogleURL.Split('@')[1].Split(',')[0].Replace('.', ',') : "0");
            model.SourceLongitude = Convert.ToDouble((request.Longitude == null) ? request.GoogleURL.Split('@')[1].Split(',')[1].Replace('.', ',') : "0");

            model.Latitude = Convert.ToDouble((CultureInfo.InstalledUICulture.Name == "en-US") ? dataUser.Branch.Latitud.Replace(',', '.') : dataUser.Branch.Latitud);
            model.Longitude = Convert.ToDouble((CultureInfo.InstalledUICulture.Name == "en-US") ? dataUser.Branch.Longitud.Replace(',', '.') : dataUser.Branch.Longitud);

            var positionToBranch = _googleMapService.GetCurrentPosition(model);

            currentPosition.Km += positionToBranch.Km;

            return currentPosition;
        }

        private async Task<Domain.Entities.ExpenseAggregate.Expense> GetLatestVisit(long userId)
        {
            var visits = await _unitOfWork
                                 .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                                 .ListAsync(new ExpenseByBeforeVisitSpecification(userId));
            return visits.Any() ? visits.First() : null;
        }

        private async Task<List<Domain.Entities.ExpenseAggregate.Expense>> GetVisits(long userId)
        {
            var visits = await _unitOfWork
                                 .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                                 .ListAsync(new ExpenseByBeforeVisitSpecification(userId));
            return visits.Any() ? (List<Domain.Entities.ExpenseAggregate.Expense>)visits : null;
        }
    }
}
