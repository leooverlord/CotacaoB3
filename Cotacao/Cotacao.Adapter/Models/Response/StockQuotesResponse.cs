namespace Cotacao.Adapter.Models.Response
{
    public class StockQuotesResponse
    {
        public StockQuotesResponse(Metadata meta, TimeSeries[] data)
        {
            Meta = meta;
            Data = data;
        }

        public Metadata Meta { get; }

        public TimeSeries[] Data { get; }

        public override string ToString()
        {
            return $"{Meta}";
        }
    }
}
