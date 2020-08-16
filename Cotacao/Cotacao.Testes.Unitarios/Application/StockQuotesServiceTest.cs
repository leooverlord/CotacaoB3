using AutoFixture;
using Cotacao.Adapter.Interfaces;
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
        private IFixture fixture;
        private StockQuotesService service;
        private Mock<IStockQuotesAdapter> adapter;

        [OneTimeSetUp]
        public void Setup()
        {
            fixture = new Fixture();
            var response = fixture.Create<StockQuotesResponse>();

            adapter = new Mock<IStockQuotesAdapter>();
            adapter.Setup(x => x.GetStockQuotes(It.IsAny<string>())).Returns(Task.FromResult(response));

            service = new StockQuotesService(adapter.Object);
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
