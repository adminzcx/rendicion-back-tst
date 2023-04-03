using Prome.Viaticos.Server.Domain.Enums;
using Prome.Viaticos.Server.Domain.ValueObjects.LunchAggregate;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application._Common.Interfaces
{

    public interface IFtpService
    {
        Task<Collection<FileImported>> DownloadExcelFilesFromFtp(FileImportationEnum source);
    }
}
