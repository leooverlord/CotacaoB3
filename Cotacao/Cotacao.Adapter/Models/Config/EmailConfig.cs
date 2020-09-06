using Cotacao.Adapter.Interfaces.Email;

namespace Cotacao.Adapter.Models.Config
{
    public class EmailConfig : IEmailConfig
    {
        public AddressMail FromAddress { get; set; }
        public AddressMail ToAddress { get; set; }
        public Smtp Smtp { get; set; }
    }
}
