using Domain.Entidades;
using System;
using System.Collections.Generic;

namespace Cotacao.Domain.Entidades
{
    public class StockQuotes
    {
        public List<StocksData> Dados { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCompleta { get; set; }
    }
}
