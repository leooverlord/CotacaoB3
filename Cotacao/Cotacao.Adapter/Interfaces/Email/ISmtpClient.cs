using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces.Email
{
    public interface ISmtpClient
    {
        Task SendMailAsync(MailMessage mailMessage);
    }
}
