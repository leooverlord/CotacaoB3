using Cotacao.Adapter.Models.Response;
using Cotacao.Domain.Entidades;

namespace Cotacao.Service.Interfaces.Mappers
{
    public interface IStockQuoteMapper
    {
        StockQuotes Map(StockQuotesResponse res);
    }
}
