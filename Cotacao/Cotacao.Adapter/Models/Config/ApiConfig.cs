using System.Collections.Generic;

namespace Cotacao.Adapter.Models.Config
{
    internal class ApiConfig
    {
        public string BaseAdress { get; set; }
        public List<Header> Headers { get; set; }
        public EmailConfig Email { get; set; }
    }
}
