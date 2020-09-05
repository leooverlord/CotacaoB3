using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cotacao.Adapter.Models.Response
{
    public class StockQuotesResponse
    {
        [JsonProperty("data")]
        public List<StocksDataResponse> Data { get; set; }

        [JsonProperty("lastUpdate")]
        public long LastUpdate { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timeOffSet")]
        public int TimeOffSet { get; set; }

        [JsonProperty("today")]
        public long Today { get; set; }
    }
}
