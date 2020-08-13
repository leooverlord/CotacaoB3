using Newtonsoft.Json;

namespace Cotacao.Adapter.Models
{
    public class Results
    {
        [JsonProperty(PropertyName = "CSNA3")]
        public CSNA3 CSNA3 { get; set; }

        [JsonProperty(PropertyName = "IRBR3")]
        public IRBR3 IRBR3 { get; set; }

        [JsonProperty(PropertyName = "COGN3")]
        public COGN3 COGN3 { get; set; }

        [JsonProperty(PropertyName = "GOLL4")]
        public GOLL4 GOLL4 { get; set; }

        [JsonProperty(PropertyName = "USIM5")]
        public USIM5 USIM5 { get; set; }

        [JsonProperty(PropertyName = "EMBR3")]
        public EMBR3 EMBR3 { get; set; }

        [JsonProperty(PropertyName = "AZUL4")]
        public AZUL4 AZUL4 { get; set; }

        [JsonProperty(PropertyName = "CYRE3")]
        public CYRE3 CYRE3 { get; set; }

        [JsonProperty(PropertyName = "BRDT3")]
        public BRDT3 BRDT3 { get; set; }

        [JsonProperty(PropertyName = "MYPK3")]
        public MYPK3 MYPK3 { get; set; }

    }
}
