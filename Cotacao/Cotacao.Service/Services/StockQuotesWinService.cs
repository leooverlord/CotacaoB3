using Cotacao.Adapter.Interfaces.Email;
using Cotacao.Application.Interfaces;
using Cotacao.Service.Interfaces;
using Cotacao.Service.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Service.Services
{
    public class StockQuotesWinService : IStockQuotesWinService
    {
        private readonly IStockQuotesService _stockQuotesService;
        private readonly IEmailService _emailService;
        private readonly IEmailConfig _emailConfig;

        public StockQuotesWinService(IStockQuotesService stockQuotesService, IEmailService emailService, IEmailConfig emailConfig)
        {
            _stockQuotesService = stockQuotesService;
            _emailService = emailService;
            _emailConfig = emailConfig;
        }

        public async Task Start(StockQuotesArguments arguments)
        {
            var emailMessage = new MailMessage(_emailConfig.FromAddress.Address, _emailConfig.ToAddress.Address)
            {
                Subject = $"Cotação {arguments.Symbol}"
            };

            Console.WriteLine("Iniciando serviço de cotações...");
            var response = await _stockQuotesService.GetStockQuotes(arguments.Symbol);

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

                if (data.Close >= arguments.High)
                {
                    Console.WriteLine("Enviando e-mail para venda");
                    emailMessage.Body = $"Valor de venda {data.Close}";
                }

                if (data.Close <= arguments.Low)
                {
                    Console.WriteLine("Enviando e-mail para compra");
                    emailMessage.Body = $"Valor de compra {data.Close}";
                }

                await _emailService.Send(emailMessage);

                Console.WriteLine("-----------------------------------------------------------------------------------");
            }
        }

        public void Stop()
        {
            Console.WriteLine("Encerrando serviço de cotações...");
        }
    }
}
