using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Adapter.Models.Response;
using Cotacao.Domain.Enums;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Adapters
{
    public class StockQuotesAdapter : IStockQuotesAdapter
    {
        private readonly IStockQuotesServiceApi _serviceApi;

        public StockQuotesAdapter(IStockQuotesServiceApi serviceApi)
        {
            _serviceApi = serviceApi;
        }

        public async Task<StockQuotesResponse> GetStockQuotes(Symbols symbol, StockQueryParams queryParams)
        {
            return await _serviceApi.GetStockQuotes((int)symbol, queryParams);
        }

    }
}
