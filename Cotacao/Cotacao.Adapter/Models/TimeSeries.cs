using System;

namespace Cotacao.Adapter.Models
{
    public class TimeSeries
    {
        public DateTime Timestamp { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public long Volume { get; set; }
    }
}
