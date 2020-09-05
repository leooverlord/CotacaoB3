using Cotacao.Adapter.Models.Response;
using Cotacao.Domain.Entidades;
using Cotacao.Service.Interfaces.Mappers;

namespace Cotacao.Service.Mappers
{
    public class StockQuoteMapper : MapperBase<StockQuotesResponse, StockQuotes>, IStockQuoteMapper
    {
        private readonly IStockDataMapper _stockDataMapper;
        public StockQuoteMapper(IStockDataMapper stockDataMapper)
        {
            _stockDataMapper = stockDataMapper;
        }

        public override StockQuotes Map(StockQuotesResponse res)
        {
            return new StockQuotes
            {
                Dados = _stockDataMapper.Map(res.Data),
                UltimaAtualizacao = UnixTimeToDateTime(res.LastUpdate),
                Tipo = res.Type,
                DataCompleta = UnixTimeToDateTime(res.Today)
            };
        }
    }
}
