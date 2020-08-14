using Cotacao.Adapter.Models.Response;
using Refit;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces
{
    public interface IStockQuotesServiceApi
    {
        [Get("/finance/stock_price?key=dd0b30d4&symbol={symbol}")]
        Task<StockQuoteResponse> GetStockQuotes(string symbol);
    }
}
