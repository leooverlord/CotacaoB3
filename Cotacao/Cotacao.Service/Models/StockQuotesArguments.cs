namespace Cotacao.Service.Models
{
    public class StockQuotesArguments
    {
        public string Symbol { get; set; }
        public float High { get; set; }
        public float Low { get; set; }

        public StockQuotesArguments(string symbol, float high, float low)
        {
            Symbol = symbol;
            High = high;
            Low = low;
        }
    }
}
