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
            Assert.NotNull(stockQuotes.Data);   
        }

        public static IEnumerable<string> Symbols()
        {
            return SymbolsHelper.GetSymbols();
        }
    }
}
