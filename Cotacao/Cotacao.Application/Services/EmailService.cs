using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Application.Interfaces;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailAdapter _adapter;
        public EmailService(IEmailAdapter adapter)
        {
            _adapter = adapter;
        }
        public async Task Send(MailMessage message)
        {
            await _adapter.Send(message);
        }
    }
}
