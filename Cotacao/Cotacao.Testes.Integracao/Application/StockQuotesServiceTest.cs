using Autofac;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Application.Interfaces;
using Cotacao.Domain.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Test, TestCaseSource(nameof(GetSymbols))]
        public async Task DeveSerPossivelObterCotacoes(Symbols symbol)
        {
            var response = await service.GetStockQuotes(symbol, new StockQueryParams(10));

            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }

        public static IEnumerable<Symbols> GetSymbols()
        {
            return Enum.GetValues(typeof(Symbols)).Cast<Symbols>();
        }
    }
}
