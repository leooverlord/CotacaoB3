using Cotacao.Adapter.Interfaces;
using Cotacao.Adapter.Models.Response;
using Cotacao.Application.Interfaces;
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

        public async Task<StockQuotesResponse> GetStockQuotes(string symbol)
        {
            return await _adapter.GetStockQuotes(symbol);
        }
    }
}
