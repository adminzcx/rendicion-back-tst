using MediatR;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseFormAudit.Queries.GetAllExpenseFormAuditByExpenseFormId
{

    public class GetAllExpenseFormAuditByExpenseFormIdQuery : IRequest<ICollection<ExpenseFormListDto>>
    {
        public int ExpenseFormId { get; set; }

    }
}
