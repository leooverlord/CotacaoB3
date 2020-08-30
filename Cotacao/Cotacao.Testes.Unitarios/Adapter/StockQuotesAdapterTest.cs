using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models.Config;
using Cotacao.Domain.Helpers;
using Cotacao.Testes.Unitarios.Mocks;
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
        private Mock<IStockQuotesServiceApi> serviceApi;
        private Mock<IApiConfig> apiConfig;

        [OneTimeSetUp]
        public void Setup()
        {
            var headers = new List<Header> { new Header { Key = "x-rapidapi-host", Value = "host" }, new Header { Key = "x-rapidapi-key", Value = "apiKey" } };

            apiConfig = new Mock<IApiConfig>();
            apiConfig.Setup(x => x.Headers).Returns(headers);

            serviceApi = new Mock<IStockQuotesServiceApi>();
            serviceApi.Setup(x => x.GetStockQuotes(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(StockDailyMock.Data));

            adapter = new StockQuotesAdapter(apiConfig.Object, serviceApi.Object);
        }

        [Test, TestCaseSource(nameof(Symbols))]
        public async Task DeveSerPossivelObterCotacoes(string symbol)
        {
            var stockQuotes = await adapter.GetStockQuotes(apiConfig.Object, symbol);

            Assert.NotNull(stockQuotes);
            Assert.NotNull(stockQuotes.Data);

            serviceApi.Verify(x => x.GetStockQuotes(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);

        }

        public static IEnumerable<string> Symbols()
        {
            return SymbolsHelper.GetSymbols();
        }
    }
}
