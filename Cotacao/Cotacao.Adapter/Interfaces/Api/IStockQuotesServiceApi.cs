using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Adapter.Models.Response;
using Refit;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces.Api
{
    public interface IStockQuotesServiceApi
    {
        [Get("/ws/asset/{symbol}/intraday")]
        //[Get("/ws/asset/484/intraday?replicate=true&size=10")]
        Task<StockQuotesResponse> GetStockQuotes(int symbol, StockQueryParams queryParams);
    }
}
