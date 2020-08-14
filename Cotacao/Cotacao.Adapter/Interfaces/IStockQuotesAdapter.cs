using Cotacao.Adapter.Models;
using Cotacao.Adapter.Models.Response;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces
{
    public interface IStockQuotesAdapter
    {
        Task<StockQuoteResponse> GetStockQuotes(string symbol);
    }
}
