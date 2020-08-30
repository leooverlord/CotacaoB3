using Autofac;
using Cotacao.Application.Interfaces;
using Cotacao.Domain.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Testes.Integracao.Application
{
    [TestFixture]
    public class StockQuotesServiceTest : SetupIntegracao
    {
        IStockQuotesService service;

        [OneTimeSetUp]
        public void Setup()
        {
            service = Container.Resolve<IStockQuotesService>();
        }

        [Test, TestCaseSource(nameof(Symbols))]
        public async Task DeveSerPossivelObterCotacoes(string symbol)
        {
            var response = await service.GetStockQuotes(symbol);

            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.NotNull(response.Meta);
        }

        public static IEnumerable<string> Symbols()
        {
            return SymbolsHelper.GetSymbols();
        }
    }
}
