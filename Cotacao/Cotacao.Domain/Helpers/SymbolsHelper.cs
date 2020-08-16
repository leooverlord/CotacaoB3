using System.Collections.Generic;

namespace Cotacao.Domain.Helpers
{
    public class SymbolsHelper
    {

        public const string Petr4 = "petr4.sa";


        public static IEnumerable<string> GetSymbols()
        {
            return new List<string>
            {
                Petr4
            };
        }
    }
}
