using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models.Config;
using Cotacao.Adapter.Models.Response;
using Cotacao.Application.Interfaces;
using System.Threading.Tasks;

namespace Cotacao.Application.Services
{
    public class StockQuotesService : IStockQuotesService
    {
        private readonly IStockQuotesAdapter _adapter;
        private readonly IApiConfig _apiConfig;

        public StockQuotesService(IApiConfig apiConfig, IStockQuotesAdapter adapter)
        {
            _adapter = adapter;
            _apiConfig = apiConfig;
        }

        public async Task<StockQuotesResponse> GetStockQuotes(string symbol)
        {
            return await _adapter.GetStockQuotes(_apiConfig, symbol);
        }
    }
}
