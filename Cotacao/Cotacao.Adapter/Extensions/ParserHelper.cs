using Cotacao.Adapter.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Cotacao.Adapter.Extensions
{
    public static class ParserHelper
    {
        public static Metadata ParseMetaData(JToken token)
        {
            var data = new Dictionary<string, string>();
            foreach (var metaData in token.Children<JProperty>())
            {
                var key = metaData.Name.Substring(3);
                var val = metaData.Value.Value<string>();
                data.Add(key, val);
            }

            return new Metadata(data);
        }

        public static IEnumerable<TimeSeries> ParseData(JToken token)
        {
            var properties = token as JProperty;
            return properties.First.Children()
                .Select(x => ((JProperty)x).ToTimeSeries())
                .ToList();
        }
    }
}
