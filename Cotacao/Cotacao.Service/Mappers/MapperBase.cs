using System;
using System.Collections.Generic;
using System.Linq;

namespace Cotacao.Service.Mappers
{
    public abstract class MapperBase<T, TResult>
    {
        public abstract TResult Map(T obj);

        public List<TResult> Map(IEnumerable<T> objs)
        {
            return objs.Select(Map).ToList();
        }

        protected DateTime UnixTimeToDateTime(long unixtime)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
    }
}
