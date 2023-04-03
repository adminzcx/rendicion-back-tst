using MediatR;
using Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Queries.GetAllUserSubstitution
{


    public class GetAllUserSubstitutionQuery : IRequest<ICollection<UserSubstitutionDto>>
    {
    }
}
