using Autofac;
using Cotacao.Application.Interfaces;
using Cotacao.Domain.Helpers;
using NUnit.Framework;
using System.Collections.Generic;

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
        public void DeveSerPossivelObterCotacoes(string symbol)
        {
            var response = service.GetStockQuotes(symbol);

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
        }

        public static IEnumerable<string> Symbols()
        {
            return SymbolsHelper.GetSymbols();
        }
    }
}
