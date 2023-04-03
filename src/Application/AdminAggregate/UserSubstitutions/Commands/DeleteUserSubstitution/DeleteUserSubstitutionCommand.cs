using MediatR;
namespace Prome.Viaticos.Server.Application.AdminAggregate.UserSubstitutions.Commands.DeleteUserSubstitution
{


    public class DeleteUserSubstitutionCommand : IRequest
    {
        public int Id { get; set; }
    }
}
