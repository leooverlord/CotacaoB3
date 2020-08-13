using Newtonsoft.Json;

namespace Cotacao.Adapter.Models
{
    public class MarketTime
    {
        [JsonProperty(PropertyName = "open")]
        public string Open { get; set; }

        [JsonProperty(PropertyName = "close")]
        public string Close { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public int Timezone { get; set; }
    }
}
