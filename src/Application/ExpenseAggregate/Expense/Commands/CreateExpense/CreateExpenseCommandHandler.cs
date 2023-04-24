
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
                entity.Latitude = map.Latitude;
                entity.Longitude = map.Longitude;
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

            await _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Expense>().AddAsync(entity);
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

            if (request.Device.ToLower() == nameof(ExpenseSourceEnum.Web).ToLower() && string.IsNullOrEmpty(request.GoogleURL)) return null;
            if (request.Device == nameof(ExpenseSourceEnum.Mobile) && (request.Latitude == 0 || request.Latitude == 0)) return null;


            string path = _configuration["MySettings:GoogleMapPath"];
            ExpenseFolderGuard.PathFolderValid(path);

            Map model = new Map();
            model.Token = _configuration["MySettings:TokenGoogleMap"];
            model.Url = request.GoogleURL;
            model.Latitude = Convert.ToDouble(request.Latitude);
            model.Longitude = Convert.ToDouble(request.Longitude);


            if (source.Id == (int)SourceEnum.Sucursal)
            {
                model.SourceLatitude = Convert.ToDouble(_configuration["MySettings:BranchLatitude"], CultureInfo.InvariantCulture);
                model.SourceLongitude = Convert.ToDouble(_configuration["MySettings:BranchLongitude"], CultureInfo.InvariantCulture);
            }
            if (source.Id == (int)SourceEnum.VisitaAnterior)
            {
                var latestVisit = await this.GetLatestVisit(userId);

                if (latestVisit != null)
                {
                    model.SourceLatitude = Convert.ToDouble(latestVisit.Latitude);
                    model.SourceLongitude = Convert.ToDouble(latestVisit.Longitude);
                }
                else
                {
                    model.SourceLatitude = Convert.ToDouble(_configuration["MySettings:BranchLatitude"], CultureInfo.InvariantCulture);
                    model.SourceLongitude = Convert.ToDouble(_configuration["MySettings:BranchLongitude"], CultureInfo.InvariantCulture);
                }
            }

            return _googleMapService.GetCurrentPosition(model);
        }

        private async Task<Domain.Entities.ExpenseAggregate.Expense> GetLatestVisit(long userId)
        {
            var visits = await _unitOfWork
                                 .Repository<Domain.Entities.ExpenseAggregate.Expense>()
                                 .ListAsync(new ExpenseByBeforeVisitSpecification(userId));
            return visits.Any() ? visits.First() : null;
        }
    }
}
