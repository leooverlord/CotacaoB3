using Cotacao.Adapter.Interfaces.Email;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Wrapper
{
    public class SmtpClientWrapper : ISmtpClient
    {
        private readonly SmtpClient _smtpClient;
        public SmtpClientWrapper(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendMailAsync(MailMessage mailMessage)
        {
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
