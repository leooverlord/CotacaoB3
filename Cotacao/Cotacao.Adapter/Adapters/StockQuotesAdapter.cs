using Cotacao.Adapter.Interfaces;
using Cotacao.Adapter.Models.Response;
using Refit;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Adapters
{
    public class StockQuotesAdapter : IStockQuotesAdapter
    {
        public async Task<StockQuoteResponse> GetStockQuotes(string symbol)
        {
            var client = RestService.For<IStockQuotesServiceApi>("https://api.hgbrasil.com");

            return await client.GetStockQuotes(symbol);
        }
    }
}
