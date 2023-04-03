using MediatR;

namespace Prome.Viaticos.Server.Application.UserAggregate.Users.Commands.DeleteUser
{

    public class DeleteUserCommand : IRequest
    {
        public string EmployeeRecord { get; set; }
    }
}
