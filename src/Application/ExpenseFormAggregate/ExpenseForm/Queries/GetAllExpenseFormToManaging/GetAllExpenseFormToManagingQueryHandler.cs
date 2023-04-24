using Ardalis.GuardClauses;
using AutoMapper;
using Prome.Viaticos.Server.Application._Common.Handlers;
using Prome.Viaticos.Server.Application._Common.Specifications;
using Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Specifications;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Specifications;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Guards;
using Prome.Viaticos.Server.Application.UserAggregate.Users.Specifications;
using Prome.Viaticos.Server.Domain.Entities.AdminAggregate;
using Prome.Viaticos.Server.Domain.Entities.UserAggregate;
using Prome.Viaticos.Server.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Queries.GetAllExpenseFormToManaging
{

    public class GetAllExpenseFormToManagingQueryHandler : QueryHandler<GetAllExpenseFormToManagingQuery
                                                            , ICollection<ExpenseFormListDto>>
    {
        public GetAllExpenseFormToManagingQueryHandler(
            IAsyncUnitOfWork unitOfWork,
            IMapper mapper)
            : base(unitOfWork, mapper)
        { }

        public override async Task<ICollection<ExpenseFormListDto>> Handle(GetAllExpenseFormToManagingQuery request
                                                                            , CancellationToken cancellationToken)
        {
            var currentUser = await this.GetCurrentUserAsync(request.Email);
            var usersToManage = await this.GetAllUsersAsync(currentUser, (ExpenseExternalAuthEnum)request.ExpenseExternalAuth);

            var subtitutionUsers = await _unitOfWork
                                        .Repository<UserSubstitution>()
                                        .ListAsync(new UserSubstitutionByUserSpecification(currentUser.Id));

            foreach (var subtitutionUser in subtitutionUsers.Select(x => x.User))
            {
                var derivedUserToManage = await this.GetAllUsersAsync(subtitutionUser, (ExpenseExternalAuthEnum)request.ExpenseExternalAuth);

                if (derivedUserToManage.Any())
                    usersToManage.AddRange(derivedUserToManage);
            }

            switch ((ExpenseExternalAuthEnum)request.ExpenseExternalAuth)
            {
                case ExpenseExternalAuthEnum.Directa:
                    {
                        var list = await _unitOfWork
                            .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                            .ListAsync(new ExpenseFormForManagingSpecification(usersToManage, ExpenseFormStatusEnum.Presentada));
                        return Map(list);
                    }
                case ExpenseExternalAuthEnum.Revisar:
                    {
                        var list = await _unitOfWork
                            .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                            .ListAsync(new ExpenseFormForManagingSpecification(usersToManage, ExpenseFormStatusEnum.Autorizado));
                        return Map(list);
                    }
                case ExpenseExternalAuthEnum.Aprobar:
                    {
                        var list = await _unitOfWork
                            .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                            .ListAsync(new ExpenseFormForManagingSpecification(usersToManage, ExpenseFormStatusEnum.Revisado));
                        return Map(list);
                    }

                case ExpenseExternalAuthEnum.Pares:
                    {
                        var list = await _unitOfWork
                            .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                            .ListAsync(new ExpenseFormForManagingSpecification(usersToManage, ExpenseFormStatusEnum.Presentada));
                        return Map(list);
                    }

                case ExpenseExternalAuthEnum.Pagar:
                {
                    var list = await _unitOfWork
                        .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                        .ListAsync(new ExpenseFormForManagingSpecification(usersToManage, ExpenseFormStatusEnum.Aprobado,false));
                    return Map(list);
                }

                default:
                    {
                        var list = await _unitOfWork
                            .Repository<Domain.Entities.ExpenseFormAggregate.ExpenseForm>()
                            .ListAsync(new ExpenseFormForManagingSpecification(usersToManage, ExpenseFormStatusEnum.Presentada));
                        return Map(list);
                    }
            }
        }

        private async Task<User> GetCurrentUserAsync(string email)
        {
            var users = await _unitOfWork
                 .Repository<User>()
                 .ListAsync(new ByEmployeeEmailSpecification(email));

            Guard.Against.Null(users, nameof(email));
            Guard.Against.IsValidUser(users);

            return users.First();
        }

        private async Task<List<long>> GetAllUsersAsync(User currentUser, ExpenseExternalAuthEnum typeAuth)
        {
            ICollection<PositionTypeEnum> firstLevelAdmin;

            switch (typeAuth)
            {
                case ExpenseExternalAuthEnum.Directa:
                    firstLevelAdmin = currentUser.FirstLevelPosition;
                    break;
                case ExpenseExternalAuthEnum.Indirecta:
                    firstLevelAdmin = currentUser.IndirectsPosition;
                    break;
                case ExpenseExternalAuthEnum.Pares:
                    firstLevelAdmin = currentUser.ParesLevelPosition;
                    break;
                default:
                    firstLevelAdmin = currentUser.ParesLevelPosition;
                    break;
            }

            Guard.Against.Null(firstLevelAdmin, "FirstLevelAdmin");

            var result = new List<long>();
            foreach (var item in firstLevelAdmin)
            {
                var codePosition = Enum.GetName(typeof(PositionTypeEnum), item);
                var position = await this.GetPositionAsync(codePosition);

                long? subZoneId = null;
                if (position.IsSubZoneRequired && currentUser.SubZone != null)
                    subZoneId = currentUser.SubZone.Id;

                long? zoneId = null;
                if (position.IsZoneRequired && currentUser.Zone != null)
                    zoneId = currentUser.Zone.Id;

                long? sectorId = null;
                if (position.IsSectorRequired && currentUser.Sector != null)
                    sectorId = currentUser.Sector.Id;

                var users = await _unitOfWork
                     .Repository<User>()
                     .ListAsync(new ByEmployeePositionSpecification(codePosition, subZoneId, zoneId, sectorId));

                if (users.Any()) result.AddRange(users.Select(x => x.Id).ToList());
            }

            return result;
        }

        private async Task<Position> GetPositionAsync(string code)
        {
            var result = await _unitOfWork
                        .Repository<Position>()
                        .SingleOrDefaultAsync(new ByCodeSpecification<Position>(code));
            Guard.Against.Null(result, nameof(code));
            return result;
        }
    }
}
