using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Adapter.Models.Response;
using Cotacao.Domain.Enums;
using System.Threading.Tasks;

namespace Cotacao.Application.Interfaces
{
    public interface IStockQuotesService
    {
        Task<StockQuotesResponse> GetStockQuotes(Symbols symbol, StockQueryParams queryParams);
    }
}
