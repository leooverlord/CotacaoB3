using AutoFixture;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Adapter.Models.Response;
using Cotacao.Application.Services;
using Cotacao.Domain.Enums;
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

            adapter = new Mock<IStockQuotesAdapter>();
            adapter.Setup(x => x.GetStockQuotes(It.IsAny<Symbols>(), It.IsAny<StockQueryParams>())).Returns(Task.FromResult(response));

            service = new StockQuotesService(adapter.Object);
        }

        [Test]
        public async Task DeveSerPossivelObterCotacoes()
        {
            var response = await service.GetStockQuotes(Symbols.PETR4, new StockQueryParams(10));
            Assert.NotNull(response);
            Assert.NotNull(response.Data);
        }
    }
}
