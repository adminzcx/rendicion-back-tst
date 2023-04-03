using Prome.Viaticos.Server.Application.CashFormAggregate.CashForm.Dtos;

namespace Prome.Viaticos.Server.Application._Common.Interfaces
{

    public interface ICashFormToCalipsoService
    {
        byte[] GetExcelFile(CashFormDto cashForm);

        string GetMimeType();
    }
}
