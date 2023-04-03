namespace Prome.Viaticos.Server.Application.ExpenseAggregate.Expense.Dtos
{

    public class DocumentAttachedDto
    {
        public byte[] DocumentAttached { get; set; }

        public string Mime { get; set; }

        public string FileName { get; set; }
    }
}
