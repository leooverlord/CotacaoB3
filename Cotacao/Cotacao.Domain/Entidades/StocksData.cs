using System;

namespace Domain.Entidades
{
    public class StocksData
    {
        public DateTime Data { get; set; }
        public double Preco { get; set; }
        public double Minimo { get; set; }
        public double Maximo { get; set; }
        public double Variacao { get; set; }
        public double VariacaoPercentual { get; set; }
        public long Volume { get; set; }

        public override string ToString()
        {
            return $@"Preço: {Preco} {Environment.NewLine}Maximo: {Maximo} {Environment.NewLine}Minimo: {Minimo} {Environment.NewLine}Variação Percentual: {VariacaoPercentual} {Environment.NewLine}Volume: {Volume} {Environment.NewLine}Horario: {Data}";
        }
    }
}
