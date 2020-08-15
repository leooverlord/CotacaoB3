using Autofac;
using Cotacao.Adapter.Interfaces;
using Cotacao.Domain.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Testes.Integracao.Adapter
{
    [TestFixture]
    public class StockQuotesAdapterTest : SetupIntegracao
    {
        private IStockQuotesAdapter adapter;

        [OneTimeSetUp]
        public void Setup()
        {
            adapter = Container.Resolve<IStockQuotesAdapter>();
        }

        [Test, TestCaseSource(nameof(Symbols))]
        public async Task DeveSerPossivelObterCotacoes(string symbol)
        {
            var stockQuotes = await adapter.GetStockQuotes(symbol);

            Assert.NotNull(stockQuotes);
            Assert.NotNull(stockQuotes.Results);

            switch (symbol)
            {
                case SymbolsHelper.Csna3:
                    Assert.NotNull(stockQuotes.Results.CSNA3);
                    break;

                case SymbolsHelper.Irbr3:
                    Assert.NotNull(stockQuotes.Results.IRBR3);
                    break;

                case SymbolsHelper.Cogn3:
                    Assert.NotNull(stockQuotes.Results.COGN3);
                    break;

                case SymbolsHelper.Goll4:
                    Assert.NotNull(stockQuotes.Results.GOLL4);
                    break;

                case SymbolsHelper.Usim5:
                    Assert.NotNull(stockQuotes.Results.USIM5);
                    break;

                case SymbolsHelper.Embr3:
                    Assert.NotNull(stockQuotes.Results.EMBR3);
                    break;

                case SymbolsHelper.Azul4:
                    Assert.NotNull(stockQuotes.Results.AZUL4);
                    break;

                case SymbolsHelper.Cyre3:
                    Assert.NotNull(stockQuotes.Results.CYRE3);
                    break;

                case SymbolsHelper.Brdt3:
                    Assert.NotNull(stockQuotes.Results.BRDT3);
                    break;

                case SymbolsHelper.Mypk3:
                    Assert.NotNull(stockQuotes.Results.MYPK3);
                    break;
            }
        }

        public static IEnumerable<string> Symbols()
        {
            return SymbolsHelper.GetSymbols();
        }
    }
}
