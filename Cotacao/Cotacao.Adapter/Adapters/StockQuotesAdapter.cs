using Cotacao.Adapter.Interfaces;
using Cotacao.Adapter.Models.Response;
using Microsoft.Extensions.Configuration;
using Refit;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Adapters
{
    public class StockQuotesAdapter : IStockQuotesAdapter
    {
        public readonly IConfiguration _configuration;
        private readonly IStockQuotesServiceApi _serviceApi;

        public StockQuotesAdapter(IConfiguration configuration, IStockQuotesServiceApi serviceApi)
        {
            _serviceApi = serviceApi;
            _configuration = configuration;
        }

        public async Task<StockQuoteResponse> GetStockQuotes(string symbol)
        {
            var apiKey = _configuration.GetSection("HgBrasilApi").GetSection("key").Value;
            return await _serviceApi.GetStockQuotes(apiKey, symbol);
        }
    }
}
