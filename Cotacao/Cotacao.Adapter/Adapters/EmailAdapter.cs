using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Email;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Adapters
{
    public class EmailAdapter : IEmailAdapter
    {
        private readonly ISmtpClient _smtpClient;
        public EmailAdapter(ISmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task Send(MailMessage message)
        {
            await _smtpClient.SendMailAsync(message);
        }
    }
}
