using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models.Response;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces.Adapter
{
    public interface IStockQuotesAdapter
    {
        Task<StockQuotesResponse> GetStockQuotes(IApiConfig apiConfig, string symbol);
    }
}
