using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces.Adapter
{
    public interface IEmailAdapter
    {
        Task Send(MailMessage message);
    }
}
