using Cotacao.Adapter.Interfaces;
using Cotacao.Adapter.Models;
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
            adapter = new Mock<IStockQuotesAdapter>();
            adapter.Setup(x => x.GetStockQuotes(It.IsAny<string>())).Returns(Task.FromResult(new StockQuoteResponse { Results = new Results() }));

            service = new StockQuotesService(adapter.Object);
        }

        [Test]
        public void DeveSerPossivelObterCotacoes()
        {
            var response = service.GetStockQuotes("abcd");
            Assert.NotNull(response);
            Assert.NotNull(response.Result);
        }
    }
}
