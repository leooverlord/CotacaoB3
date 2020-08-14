using Newtonsoft.Json;

namespace Cotacao.Adapter.Models
{
    public class Symbol
    {
        [JsonProperty(PropertyName = "symbol")]
        public string SymbolName { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "market_time")]
        public MarketTime MarketTime { get; set; }

        [JsonProperty(PropertyName = "market_cap")]
        public double MarketCap { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "change_percent")]
        public double ChangePercent { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public string UpdatedAt { get; set; }
    }
}
