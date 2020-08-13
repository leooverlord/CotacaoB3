using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cotacao.Adapter.Models.Response
{
    public class StockQuoteResponse
    {
        [JsonProperty(PropertyName = "by")]
        public string By { get; set; }

        [JsonProperty(PropertyName = "valid_key")]
        public bool ValidKey { get; set; }

        [JsonProperty(PropertyName = "results")]
        public Results Results { get; set; }

        [JsonProperty(PropertyName = "execution_time")]
        public double ExecutionTime { get; set; }

        [JsonProperty(PropertyName = "from_cache")]
        public bool FromCache { get; set; }
    }
}
