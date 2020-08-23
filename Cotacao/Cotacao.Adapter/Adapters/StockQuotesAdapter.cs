using Cotacao.Adapter.Extensions;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models.Response;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Adapters
{
    public class StockQuotesAdapter : IStockQuotesAdapter
    {
        private readonly IApiConfig _apiConfig;
        private readonly IStockQuotesServiceApi _serviceApi;

        public StockQuotesAdapter(IApiConfig apiConfig, IStockQuotesServiceApi serviceApi)
        {
            _apiConfig = apiConfig;
            _serviceApi = serviceApi;
        }

        public async Task<StockQuotesResponse> GetStockQuotes(IApiConfig apiConfig, string symbol)
        {
            var headerHost = _apiConfig.Headers.FirstOrDefault(x => x.Key == "x-rapidapi-host").Value;
            var headerApiKey = _apiConfig.Headers.FirstOrDefault(x => x.Key == "x-rapidapi-key").Value;

            var apiData = await _serviceApi.GetStockQuotes(symbol, headerHost, headerApiKey);

            JToken node = JToken.Parse(apiData);

            //Parsers
            var metadataNode = node.Root["Meta Data"];
            var metadata = ParserHelper.ParseMetaData(metadataNode);
            var dataNode = node.Root.Skip(1).FirstOrDefault();
            var data = ParserHelper.ParseData(dataNode).ToArray();

            return new StockQuotesResponse(metadata, data);
        }
    }
}
