using System.Net.Mail;

namespace Cotacao.Adapter.Models.Config
{
    public class Smtp
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public SmtpDeliveryMethod DeliveryMethod => SmtpDeliveryMethod.Network;
        public bool UseDefaultCredentials { get; set; }
    }
}
