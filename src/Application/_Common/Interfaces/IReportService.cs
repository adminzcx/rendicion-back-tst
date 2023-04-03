using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;
using Prome.Viaticos.Server.Application.ExpenseFormAggregate.ExpenseForm.Dtos;
using Prome.Viaticos.Server.Application.LunchFormAggregate.LunchForm.Dtos;
using Prome.Viaticos.Server.Domain.Enums;

namespace Prome.Viaticos.Server.Application._Common.Interfaces
{
    public interface IReportService
    {
        byte[] GenerateExpenseReport(FolderPathEnum path, ExpenseFormDto expenseForm);

        byte[] GenerateLunchReport(FolderPathEnum path, LunchFormForEditDto lunchForm);

        byte[] GenerateCashReport(FolderPathEnum path, CashFormDto cashForm);

        string GetMimeType();
    }
}
