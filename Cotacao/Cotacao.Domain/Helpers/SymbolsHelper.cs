﻿using System.Collections.Generic;

namespace Cotacao.Domain.Helpers
{
    public class SymbolsHelper
    {
        public const string Csna3 = "CSNA3";
        public const string Irbr3 = "IRBR3";
        public const string Cogn3 = "COGN3";
        public const string Goll4 = "GOLL4";
        public const string Usim5 = "USIM5";
        public const string Embr3 = "EMBR3";
        public const string Azul4 = "AZUL4";
        public const string Cyre3 = "CYRE3";
        public const string Brdt3 = "BRDT3";
        public const string Mypk3 = "MYPK3";


        public static IEnumerable<string> GetSymbols()
        {
            return new List<string>
            {
                Csna3,
                Irbr3,
                Cogn3,
                Goll4,
                Usim5,
                Embr3,
                Azul4,
                Cyre3,
                Brdt3,
                Mypk3
            };
        }
    }
}