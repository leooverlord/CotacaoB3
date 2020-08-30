using Cotacao.Application.Interfaces;
using Cotacao.Service.Interfaces;
using Cotacao.Service.Models;
using System;
using System.Threading.Tasks;

namespace Cotacao.Service.Services
{
    public class StockQuotesWinService : IStockQuotesWinService
    {
        private readonly IStockQuotesService _service;
        public StockQuotesWinService(IStockQuotesService service)
        {
            _service = service;
        }

        public async Task Start(StockQuotesArguments arguments)
        {
            Console.WriteLine("Iniciando serviço de cotações...");
            var response = await _service.GetStockQuotes(arguments.Symbol);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Meta Dados...");
            foreach (var meta in response.Meta) Console.WriteLine($"{meta.Key}: {meta.Value}");

            Console.WriteLine("-----------------------------------------------------------------------------------");
            foreach (var data in response.Data)
            {
                Console.WriteLine($"Aberto: {data.Open}");
                Console.WriteLine($"Alta: {data.High}");
                Console.WriteLine($"Baixa: {data.Low}");
                Console.WriteLine($"Encerrado: {data.Close}");
                Console.WriteLine($"Volume: {data.Volume}");
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }
        }

        public void Stop()
        {
            Console.WriteLine("Encerrando serviço de cotações...");
        }
    }
}
