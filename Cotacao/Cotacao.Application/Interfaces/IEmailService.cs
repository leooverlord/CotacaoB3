using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Application.Interfaces
{
    public interface IEmailService
    {
        Task Send(MailMessage message);
    }
}
