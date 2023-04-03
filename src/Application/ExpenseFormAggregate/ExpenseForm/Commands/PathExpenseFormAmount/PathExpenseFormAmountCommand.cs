using MediatR;
namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Commands.PathExpenseFormAmount
{
    public class PathExpenseFormAmountCommand : IRequest
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

    }

}
