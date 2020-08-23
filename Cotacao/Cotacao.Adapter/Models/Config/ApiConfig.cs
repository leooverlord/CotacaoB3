using Cotacao.Adapter.Interfaces.Api;
using System.Collections.Generic;

namespace Cotacao.Adapter.Models.Config
{
    public class ApiConfig : IApiConfig
    {
        public string BaseAdress { get; set; }
        public List<Header> Headers { get; set; }
    }
}
