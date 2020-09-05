using Cotacao.Adapter.Interfaces.Email;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Application.Interfaces;
using Cotacao.Domain.Enums;
using Cotacao.Service.Interfaces;
using Cotacao.Service.Interfaces.Mappers;
using Cotacao.Service.Mappers;
using Cotacao.Service.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Timers;

namespace Cotacao.Service.Services
{
    public class StockQuotesWinService : IStockQuotesWinService
    {
        private readonly IStockQuotesService _stockQuotesService;
        private readonly IEmailService _emailService;
        private readonly IEmailConfig _emailConfig;
        private readonly IStockQuoteMapper _mapper;
        private int _tempoInicial = 60;
        private int _tempoMaximo = 60;

        public StockQuotesWinService(IStockQuotesService stockQuotesService, IEmailService emailService, IEmailConfig emailConfig, IStockQuoteMapper mapper)
        {
            _stockQuotesService = stockQuotesService;
            _emailService = emailService;
            _emailConfig = emailConfig;
            _mapper = mapper;
        }

        public async Task Start(StockQuotesArguments arguments)
        {
            while (_tempoInicial >= 0)
            {
                await Task.Delay(1000);
                await Task.Run(async () => await OnTimedEvent(arguments));
            }
        }
        public void Stop()
        {
            Console.WriteLine("Encerrando serviço de cotações...");
        }
        private async Task OnTimedEvent(StockQuotesArguments arguments)
        {
            if (_tempoInicial < _tempoMaximo)
                Console.WriteLine($"Aguarde {_tempoInicial} segundos para iniciar uma nova busca...");
            else if (_tempoInicial == _tempoMaximo)
                await GetStocks(arguments);
            if (_tempoInicial <= 0)
                _tempoInicial = _tempoMaximo;
            else
                _tempoInicial--;
        }

        private async Task GetStocks(StockQuotesArguments arguments)
        {
            try
            {
                var emailMessage = new MailMessage(_emailConfig.FromAddress.Address, _emailConfig.ToAddress.Address)
                {
                    Subject = $"Cotação B3 para {arguments.Sigla}"
                };

                var symbol = (Symbols)Enum.Parse(typeof(Symbols), arguments.Sigla.ToUpper());
                var query = new StockQueryParams(1);
                var response = await _stockQuotesService.GetStockQuotes(symbol, query);

                var stocks = _mapper.Map(response);

                Console.WriteLine("-----------------------------------------------------------------------------------");
                foreach (var cotacao in stocks.Dados)
                {
                    Console.WriteLine(cotacao.ToString());

                    if (cotacao.Preco >= arguments.Maximo)
                    {
                        Console.WriteLine("Enviando e-mail para venda");
                        emailMessage.Body = $"Valor de venda {cotacao.Preco}";
                    }

                    if (cotacao.Preco <= arguments.Minimo)
                    {
                        Console.WriteLine("Enviando e-mail para compra");
                        emailMessage.Body = $"Valor de compra {cotacao.Preco}";
                    }

                    await _emailService.Send(emailMessage);

                    Console.WriteLine("-----------------------------------------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
