using Cotacao.Adapter.Helpers;
using Cotacao.Adapter.Models;
using Newtonsoft.Json.Linq;

namespace Cotacao.Adapter.Extensions
{
    public static class JsonExtensions
    {
        public static TimeSeries ToTimeSeries(this JProperty token)
        {
            var date = DateHelper.ParseDateTime(token.Name);

            var entry = new TimeSeries
            {
                Timestamp = date,
                Open = token.First.Value<double>("1. open"),
                High = token.First.Value<double>("2. high"),
                Low = token.First.Value<double>("3. low"),
                Close = token.First.Value<double>("4. close"),
                Volume = token.First.Value<long>("5. volume")
            };

            return entry;
        }
    }
}
