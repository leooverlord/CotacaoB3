using AutoFixture;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Models.Config;
using Cotacao.Adapter.Models.Response;
using Cotacao.Application.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Cotacao.Testes.Unitarios.Application
{
    [TestFixture]
    public class StockQuotesServiceTest
    {
        private StockQuotesService service;
        private Mock<IStockQuotesAdapter> adapter;

        [OneTimeSetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            var response = fixture.Create<StockQuotesResponse>();
            var apiConfig = fixture.Create<ApiConfig>();

            adapter = new Mock<IStockQuotesAdapter>();
            adapter.Setup(x => x.GetStockQuotes(It.IsAny<ApiConfig>(), It.IsAny<string>())).Returns(Task.FromResult(response));

            service = new StockQuotesService(apiConfig, adapter.Object);
        }

        [Test]
        public async Task DeveSerPossivelObterCotacoes()
        {
            var response = await service.GetStockQuotes("abcd");
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
