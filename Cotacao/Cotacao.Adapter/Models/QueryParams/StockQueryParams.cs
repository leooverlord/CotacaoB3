using Refit;

namespace Cotacao.Adapter.Models.QueryParams
{
    public class StockQueryParams
    {
        [AliasAs("replicate")]
        public bool Replicate => true;

        [AliasAs("size")]
        public int Size { get; set; }

        public StockQueryParams(int size)
        {
            Size = size;
        }
    }
}
