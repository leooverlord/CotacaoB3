using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Models;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Adapter.Models.Response;
using Cotacao.Domain.Enums;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotacao.Testes.Unitarios.Adapter
{
    [TestFixture]
    public class StockQuotesAdapterTest
    {
        private IStockQuotesAdapter adapter;
        private Mock<IStockQuotesServiceApi> serviceApi;

        [OneTimeSetUp]
        public void Setup()
        {
            var response = new StockQuotesResponse { Data = new List<StocksDataResponse>() };

            serviceApi = new Mock<IStockQuotesServiceApi>();
            serviceApi.Setup(x => x.GetStockQuotes(It.IsAny<int>(), It.IsAny<StockQueryParams>())).Returns(Task.FromResult(response));

            adapter = new StockQuotesAdapter(serviceApi.Object);
        }

        [Test, TestCaseSource(nameof(GetSymbols))]
        public async Task DeveSerPossivelObterCotacoes(Symbols symbol)
        {
            var stockQuotes = await adapter.GetStockQuotes(symbol, new StockQueryParams(10));

            Assert.NotNull(stockQuotes);
            Assert.NotNull(stockQuotes.Data);

            serviceApi.Verify(x => x.GetStockQuotes(It.IsAny<int>(), It.IsAny<StockQueryParams>()), Times.AtLeastOnce);

        }


        public static IEnumerable<Symbols> GetSymbols()
        {
            return Enum.GetValues(typeof(Symbols)).Cast<Symbols>();
        }
    }
}
