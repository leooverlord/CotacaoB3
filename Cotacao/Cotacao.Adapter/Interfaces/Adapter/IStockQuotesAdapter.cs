using Cotacao.Adapter.Models.Response;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces.Adapter
{
    public interface IStockQuotesAdapter
    {
        Task<StockQuotesResponse> GetStockQuotes(string symbol);
    }
}
