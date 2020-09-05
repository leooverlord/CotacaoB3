namespace Cotacao.Service.Models
{
    public class StockQuotesArguments
    {
        public string Sigla { get; set; }
        public float Maximo { get; set; }
        public float Minimo { get; set; }

        public StockQuotesArguments(string sigla, float maximo, float minimo)
        {
            Sigla = sigla;
            Maximo = maximo;
            Minimo = minimo;
        }
    }
}
