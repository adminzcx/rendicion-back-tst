using Prome.Viaticos.Server.Domain.ValueObjects.Common;
using System.Threading.Tasks;

namespace Prome.Viaticos.Server.Application.Common.Interfaces
{

    public interface IEmailService
    {
        Task SendEmailAsync(Email email);
        Task SendEmailBySendGridAsync(Email email);
    }
}
