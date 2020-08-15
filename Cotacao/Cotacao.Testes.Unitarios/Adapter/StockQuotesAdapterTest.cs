﻿using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces;
using Cotacao.Adapter.Models;
using Cotacao.Adapter.Models.Response;
using Cotacao.Domain.Helpers;
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
            var results = new Results { CSNA3 = new CSNA3(), IRBR3 = new IRBR3(), COGN3 = new COGN3(), GOLL4 = new GOLL4(), USIM5 = new USIM5(), EMBR3 = new EMBR3(), AZUL4 = new AZUL4(), CYRE3 = new CYRE3(), BRDT3 = new BRDT3(), MYPK3 = new MYPK3() };
            var response = new StockQuoteResponse { Results = results };

            configuration = new Mock<IConfiguration>();
            serviceApi = new Mock<IStockQuotesServiceApi>();

            configuration.Setup(x => x.GetSection(It.IsAny<string>()).GetSection(It.IsAny<string>()).Value).Returns("chave");
            serviceApi.Setup(x => x.GetStockQuotes(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(response));

            adapter = new StockQuotesAdapter(configuration.Object, serviceApi.Object);
        }

        [Test, TestCaseSource(nameof(Symbols))]
        public async Task DeveSerPossivelObterCotacoes(string symbol)
        {
            var stockQuotes = await adapter.GetStockQuotes(symbol);

            Assert.NotNull(stockQuotes);
            Assert.NotNull(stockQuotes.Results);

            switch (symbol)
            {
                case SymbolsHelper.Csna3:
                    Assert.NotNull(stockQuotes.Results.CSNA3);
                    break;

                case SymbolsHelper.Irbr3:
                    Assert.NotNull(stockQuotes.Results.IRBR3);
                    break;

                case SymbolsHelper.Cogn3:
                    Assert.NotNull(stockQuotes.Results.COGN3);
                    break;

                case SymbolsHelper.Goll4:
                    Assert.NotNull(stockQuotes.Results.GOLL4);
                    break;

                case SymbolsHelper.Usim5:
                    Assert.NotNull(stockQuotes.Results.USIM5);
                    break;

                case SymbolsHelper.Embr3:
                    Assert.NotNull(stockQuotes.Results.EMBR3);
                    break;

                case SymbolsHelper.Azul4:
                    Assert.NotNull(stockQuotes.Results.AZUL4);
                    break;

                case SymbolsHelper.Cyre3:
                    Assert.NotNull(stockQuotes.Results.CYRE3);
                    break;

                case SymbolsHelper.Brdt3:
                    Assert.NotNull(stockQuotes.Results.BRDT3);
                    break;

                case SymbolsHelper.Mypk3:
                    Assert.NotNull(stockQuotes.Results.MYPK3);
                    break;
            }
        }

        public static IEnumerable<string> Symbols()
        {
            return SymbolsHelper.GetSymbols();
        }
    }
}