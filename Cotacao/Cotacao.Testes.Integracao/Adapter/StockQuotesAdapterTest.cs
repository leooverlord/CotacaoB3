using Autofac;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models.Config;
using Cotacao.Domain.Helpers;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Testes.Integracao.Adapter
{
    [TestFixture]
    public class StockQuotesAdapterTest : SetupIntegracao
    {
        private IStockQuotesAdapter adapter;
        private IApiConfig apiConfig;

        [OneTimeSetUp]
        public void Setup()
        {
            adapter = Container.Resolve<IStockQuotesAdapter>();
            apiConfig = Container.Resolve<IApiConfig>();
            
        }

        [Test, TestCaseSource(nameof(Symbols))]
        public async Task DeveSerPossivelObterCotacoes(string symbol)
        {
            var stockQuotes = await adapter.GetStockQuotes(apiConfig, symbol);

            Assert.NotNull(stockQuotes);
            Assert.NotNull(stockQuotes.Data);
        }

        public static IEnumerable<string> Symbols()
        {
            return SymbolsHelper.GetSymbols();
        }
    }
}
