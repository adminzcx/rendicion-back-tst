using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using System.Collections.Generic;

namespace Prome.Viaticos.Server.Application._Common.Interfaces
{

    public interface IExpenseFormToCalipsoService
    {
        byte[] GetExcelFile(ICollection<ExpenseFormDto> expenseFormList);

        string GetMimeType();
    }
}
