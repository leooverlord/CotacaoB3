using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces;
using Cotacao.Domain.Helpers;
using Cotacao.Testes.Unitarios.Mocks;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Testes.Unitarios.Adapter
{
    [TestFixture]
    public class StockQuotesAdapterTest
    {
        private IStockQuotesAdapter adapter;
        private Mock<IConfiguration> configuration;
        private Mock<IStockQuotesServiceApi> serviceApi;

        [OneTimeSetUp]
        public void Setup()
        {
            configuration = new Mock<IConfiguration>();
            serviceApi = new Mock<IStockQuotesServiceApi>();

            //configuration.Setup(x => x.GetSection(It.IsAny<string>()).GetSection(It.IsAny<string>()).Value).Returns("chave");
            serviceApi.Setup(x => x.GetStockQuotes(It.IsAny<string>())).Returns(Task.FromResult(StockDailyMock.Data));

            adapter = new StockQuotesAdapter(configuration.Object, serviceApi.Object);
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
