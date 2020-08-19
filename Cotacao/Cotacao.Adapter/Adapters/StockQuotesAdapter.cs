using Cotacao.Adapter.Extensions;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models.Config;
using Cotacao.Adapter.Models.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace Cotacao.Adapter.Adapters
{
    public class StockQuotesAdapter : IStockQuotesAdapter
    {
        public readonly IConfiguration _configuration;
        private readonly IStockQuotesServiceApi _serviceApi;

        public StockQuotesAdapter(IConfiguration configuration, IStockQuotesServiceApi serviceApi)
        {
            _serviceApi = serviceApi;
            _configuration = configuration;
        }

        public async Task<StockQuotesResponse> GetStockQuotes(string symbol)
        {
            var apiConfig = _configuration.GetSection("Api").Get<ApiConfig>();

            var apiData = await _serviceApi.GetStockQuotes(symbol, apiConfig.Headers[0].Value, apiConfig.Headers[1].Value);

            JToken node = JToken.Parse(apiData);

            var metadataNode = node.Root["Meta Data"];
            var metadata = ParserHelper.ParseMetaData(metadataNode);
            var dataNode = node.Root.Skip(1).FirstOrDefault();
            var data = ParserHelper.ParseData(dataNode).ToArray();

            return new StockQuotesResponse(metadata, data);
        }
    }
}
