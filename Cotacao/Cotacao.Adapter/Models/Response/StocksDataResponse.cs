using Newtonsoft.Json;

namespace Cotacao.Adapter.Models.Response
{
    public class StocksDataResponse
    {
        [JsonProperty("date")]
        public long Date { get; set; }
        
        [JsonProperty("price")]
        public double Price { get; set; }
        
        [JsonProperty("low")]
        public double Low { get; set; }
        
        [JsonProperty("high")]
        public double High { get; set; }
        
        [JsonProperty("var")]
        public double Var { get; set; }

        [JsonProperty("varpct")]
        public double VarPct { get; set; }

        [JsonProperty("vol")]
        public long Vol { get; set; }
    }
}
