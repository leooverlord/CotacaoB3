using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Adapter.Models.Response;
using Cotacao.Domain.Enums;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces.Adapter
{
    public interface IStockQuotesAdapter
    {
        Task<StockQuotesResponse> GetStockQuotes(Symbols symbol, StockQueryParams queryParams);
    }
}
