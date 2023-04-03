using MediatR;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Commands.ImportExcelFile
{
    public class ImportExcelFileCommandHandler : CommandHandler<ImportExcelFileCommand>
    {
        private readonly IDateTime _dateTimeService;
        private readonly IFtpService _ftpService;

        public ImportExcelFileCommandHandler(
                IAsyncUnitOfWork unitOfWork,
                IDateTime dateTimeService,
                IFtpService ftpService) : base(unitOfWork)
        {
            _dateTimeService = dateTimeService;
            _ftpService = ftpService;
        }

        public override async Task<Unit> Handle(ImportExcelFileCommand request, CancellationToken cancellationToken)
        {

            var calipsoResult = await _ftpService.DownloadExcelFilesFromFtp(FileImportationEnum.Calipso);

            foreach (var item in calipsoResult)
            {
                var user = await this.GetUserByRecordAsync(item.EmployeeRecord);
                if (user == null) continue;

                var entity = new UserAbsenteeism(user,
                    item.StartDate,
                    item.EndDate,
                    _dateTimeService.Now,
                    nameof(FileImportationEnum.Calipso));

                await _unitOfWork.Repository<UserAbsenteeism>().AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }

            var edenredResult = await _ftpService.DownloadExcelFilesFromFtp(FileImportationEnum.Edenred);

            foreach (var item in edenredResult)
            {
                var user = await this.GetUserByCuitAsync(item.EmployeeRecord);
                if (user == null) continue;

                var entity = new UserAbsenteeism(user,
                    item.StartDate,
                    item.EndDate,
                    _dateTimeService.Now,
                    nameof(FileImportationEnum.Edenred));

                await _unitOfWork.Repository<UserAbsenteeism>().AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }

            return Unit.Value;
        }

        private async Task<User> GetUserByRecordAsync(string employeeRecord)
        {
            var users = await _unitOfWork
                 .Repository<User>()
                 .ListAsync(new ByEmployeeRecordSpecification(employeeRecord));
            return !users.Any() ? null : users.First();
        }

        private async Task<User> GetUserByCuitAsync(string employeeRecord)
        {
            var users = await _unitOfWork
                .Repository<User>()
                .ListAsync(new ByEmployeeCuitSpecification(employeeRecord));
            return !users.Any() ? null : users.First();
        }
    }
}
