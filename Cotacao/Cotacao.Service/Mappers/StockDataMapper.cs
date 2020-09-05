using Cotacao.Adapter.Models.Response;
using Cotacao.Service.Interfaces.Mappers;
using Domain.Entidades;

namespace Cotacao.Service.Mappers
{
    public class StockDataMapper : MapperBase<StocksDataResponse, StocksData>, IStockDataMapper
    {
        public override StocksData Map(StocksDataResponse res)
        {
            return new StocksData
            {
                Data = UnixTimeToDateTime(res.Date),
                Preco = res.Price,
                Minimo = res.Low,
                Maximo = res.High,
                Variacao = res.Var,
                VariacaoPercentual = res.VarPct,
                Volume = res.Vol
            };
        }
    }
}
