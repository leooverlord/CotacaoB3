using Cotacao.Adapter.Models.Response;
using System.Threading.Tasks;

namespace Cotacao.Application.Interfaces
{
    public interface IStockQuotesService
    {
        Task<StockQuoteResponse> GetStockQuotes(string symbol);
    }
}
