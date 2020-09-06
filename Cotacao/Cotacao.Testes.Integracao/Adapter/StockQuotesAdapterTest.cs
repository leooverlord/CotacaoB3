using Autofac;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Domain.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Test, TestCaseSource(nameof(GetSymbols))]
        public async Task DeveSerPossivelObterCotacoes(Symbols symbol)
        {
            var stockQuotes = await adapter.GetStockQuotes(symbol, new StockQueryParams(100));

            Assert.NotNull(stockQuotes);
            Assert.NotNull(stockQuotes.Data);
            CollectionAssert.IsNotEmpty(stockQuotes.Data);
        }

        public static IEnumerable<Symbols> GetSymbols()
        {
            return Enum.GetValues(typeof(Symbols)).Cast<Symbols>();
        }
    }
}
