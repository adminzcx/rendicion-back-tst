
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

namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Commands.UpdateExpense
{


    public class UpdateExpenseCommandHandler : CommandHandler<UpdateExpenseCommand>
    {
        private readonly IDateTime _dateTimeService;
        private readonly IFileService _fileService;
        private readonly IMapService _googleMapService;
        private readonly IConfiguration _configuration;

        public UpdateExpenseCommandHandler(
            IAsyncUnitOfWork unitOfWork,
            IDateTime dateTimeService,
            IFileService fileService,
            IConfiguration configuration,
            IMapper mapper,
            IMapService googleMapService)
            : base(unitOfWork, mapper)
        {
            _dateTimeService = dateTimeService;
            _fileService = fileService;
            _googleMapService = googleMapService;
            _configuration = configuration;
        }

        public async override Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {

            var entity = await FindById<Domain.Entities.ExpenseAggregate.Expense>(request.Id);

            entity.Amount = request.Amount;
            entity.MobilityAmount = request.MobilityAmount;
            entity.Description = request.Description;
            entity.DNI = request.DNI;
            entity.ExpenseDate = request.ExpenseDate;
            entity.Term = request.Term;
            entity.TotalAmount = request.TotalAmount;
            entity.GoogleURL = request.GoogleURL;
            entity.VisitResult = request.VisitResult;
            entity.RequestNumber = request.RequestNumber;
            entity.Segment = await this.GetSegmentAsync(request.SegmentId);
            entity.Source = await this.GetSourceAsync(request.SourceId);
            entity.TechnicalVisit = await this.GetTechnicalVisitAsync(request.TechnicalVisitId);
            entity.AddUsers(await this.UpdateUsersAsync(request.Users, request.Id));

            entity.Status = await FindById<ExpenseStatus>((int)ExpenseStatusEnum.Pendiente);

            if (entity.Status.Id == (int)ExpenseStatusEnum.Rechazado)
            {
                entity.Status = await FindById<ExpenseStatus>((int)ExpenseStatusEnum.Pendiente);
            }

            if (!string.IsNullOrEmpty(request.DocumentAttached))
            {
                entity.DocumentAttached = this.UploadFile(request.URLFile, request.DocumentAttached);

            }
            entity.ExpenseForm = await this.GetExpenseFormAsync(request.ExpenseFormId);

            var map = await this.GetCurrentPositionAsync(request, entity.Source, entity.SourceLatitude, entity.SourceLongitude);
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

            #region Advices
            var expenseStopList = await this.GetExpenseStopsAsync(request.ConceptId);
            var expenseList = await this.GetExpensesAsync(entity.User.Id, entity.ExpenseDate, entity.Id);
            this.RemoveAdvicesAsync(entity);
            entity.GenerateAdvices(expenseStopList, expenseList);
            #endregion

            _unitOfWork.Repository<Domain.Entities.ExpenseAggregate.Expense>().Update(entity);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }

        private async Task<List<ExpenseUser>> UpdateUsersAsync(ICollection<ExpenseUserDto> usersDto, int expenseId)
        {
            var users = await this.GetExpenseUserByIdAsync(expenseId);

            if (usersDto != null)
            {
                var expenseUsers = new List<ExpenseUser>();

                foreach (var user in users)
                {
                    new ExpenseUser();
                    if (!usersDto.Any(x => x.Id == user.Id))
                    {
                        user.IsDeleted = true;
                    }
                    expenseUsers.Add(user);
                }


                foreach (var user in usersDto)
                {
                    if (users.All(x => x.Id != user.Id))
                    {
                        var userExpense = await FindById<User>(user.Id);
                        var expenseUserEntity = new ExpenseUser
                        {
                            User = userExpense,
                            ExpenseDate = _dateTimeService.Now
                        };
                        expenseUsers.Add(expenseUserEntity);
                    }
                }

                return expenseUsers;
            }
            else return null;
        }

        private async Task<IReadOnlyCollection<ExpenseUser>> GetExpenseUserByIdAsync(int expenseId)
        {
            return await _unitOfWork
                 .Repository<ExpenseUser>()
                 .ListAsync(new ExpenseUserByUserExpenseSpecification(expenseId));
        }

        private string UploadFile(string uRlFile, string documentAttached)
        {
            if (!string.IsNullOrEmpty(uRlFile) && !string.IsNullOrEmpty(documentAttached))
            {
                var customDocumentAttached = _dateTimeService.NowToCustomString + "-" + documentAttached;
                _fileService.UploadFile(FolderPathEnum.Expense, uRlFile, customDocumentAttached);

                return customDocumentAttached;
            }
            else return documentAttached;
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
        private void RemoveAdvicesAsync(Domain.Entities.ExpenseAggregate.Expense entity)
        {

            foreach (var item in entity.Advices)
            {
                _unitOfWork.Repository<ExpenseAdvice>().Delete(item);
            }
        }
        #endregion

        #region Map
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
        private async Task<Geolocation> GetCurrentPositionAsync(UpdateExpenseCommand request, Domain.Entities.ExpenseAggregate.Source source, double? latitude, double? longitude)
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
                model.SourceLatitude = (double)latitude;
                model.SourceLongitude = (double)longitude;
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
        #endregion
    }
}
