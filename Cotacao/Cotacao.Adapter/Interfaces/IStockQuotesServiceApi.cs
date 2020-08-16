using Refit;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Interfaces
{
    public interface IStockQuotesServiceApi
    {
        [Get("/query?outputsize=compact&datatype=json&function=TIME_SERIES_DAILY&symbol={symbol}")]
        Task<string> GetStockQuotes(string symbol, [Header("x-rapidapi-host")] string hearderHost, [Header("x-rapidapi-key")] string headerApi);
    }
}
