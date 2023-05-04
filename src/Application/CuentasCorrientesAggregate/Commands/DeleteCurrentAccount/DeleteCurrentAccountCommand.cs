using MediatR;

namespace Prome.Viaticos.Server.Application.CuentasCorrientesAggregate.Commands.DeleteCurrentAccount
{
    public class DeleteCurrentAccountCommand : IRequest
    {
        public int Id { get; set; }
    }
}
