using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Adapter.Models.Response;
using Cotacao.Application.Interfaces;
using Cotacao.Domain.Enums;
using System.Threading.Tasks;

namespace Cotacao.Application.Services
{
    public class StockQuotesService : IStockQuotesService
    {
        private readonly IStockQuotesAdapter _adapter;
        public StockQuotesService(IStockQuotesAdapter adapter)
        {
            _adapter = adapter;
        }

        public async Task<StockQuotesResponse> GetStockQuotes(Symbols symbol, StockQueryParams queryParams)
        {
            return await _adapter.GetStockQuotes(symbol, queryParams);
        }
    }
}
