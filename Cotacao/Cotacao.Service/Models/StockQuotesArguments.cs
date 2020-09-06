namespace Cotacao.Service.Models
{
    public class StockQuotesArguments
    {
        public string Ativo { get; set; }
        public double Maximo { get; set; }
        public double Minimo { get; set; }

        public StockQuotesArguments(string ativo, double maximo, double minimo)
        {
            Ativo = ativo;
            Maximo = maximo;
            Minimo = minimo;
        }
    }
}
