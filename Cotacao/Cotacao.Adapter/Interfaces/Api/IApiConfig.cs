using Cotacao.Adapter.Models.Config;
using System.Collections.Generic;

namespace Cotacao.Adapter.Interfaces.Api
{
    public interface IApiConfig
    {
        string BaseAdress { get; set; }
        List<Header> Headers { get; set; }
    }
}
