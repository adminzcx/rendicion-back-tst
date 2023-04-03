using MediatR;

namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Commands.CreateUserSubstitution
{


    public class CreateUserSubstitutionCommand : IRequest
    {
        public int UserId { get; set; }

        public int ReplaceByUserId { get; set; }
    }
}
