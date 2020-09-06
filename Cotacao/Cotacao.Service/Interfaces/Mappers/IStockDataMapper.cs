using Cotacao.Adapter.Models.Response;
using Domain.Entidades;
using System.Collections.Generic;

namespace Cotacao.Service.Interfaces.Mappers
{
    public interface IStockDataMapper
    {
        StocksData Map(StocksDataResponse res);
        List<StocksData> Map(IEnumerable<StocksDataResponse> res);
    }
}
