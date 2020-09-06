using Cotacao.Adapter.Interfaces.Email;
using Cotacao.Adapter.Models.QueryParams;
using Cotacao.Application.Interfaces;
using Cotacao.Domain.Enums;
using Cotacao.Service.Interfaces;
using Cotacao.Service.Interfaces.Mappers;
using Cotacao.Service.Models;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Service.Services
{
    public class StockQuotesWinService : IStockQuotesWinService
    {
        private readonly StockQuotesArguments _arguments;
        private readonly IStockQuotesService _stockQuotesService;
        private readonly IEmailService _emailService;
        private readonly IEmailConfig _emailConfig;
        private readonly IStockQuoteMapper _mapper;

        private int _tempoInicial = 60;
        private int _tempoMaximo = 60;

        public StockQuotesWinService(StockQuotesArguments arguments, IStockQuotesService stockQuotesService, IEmailService emailService, IEmailConfig emailConfig, IStockQuoteMapper mapper)
        {
            _arguments = arguments;
            _stockQuotesService = stockQuotesService;
            _emailService = emailService;
            _emailConfig = emailConfig;
            _mapper = mapper;
        }

        public async Task Start()
        {
            while (_tempoInicial >= 0)
            {
                await Task.Delay(1000);
                await Task.Run(async () => await OnTimedEvent());
            }
        }
        public void Stop()
        {
            Console.WriteLine("Encerrando serviço de cotações...");
        }
        private async Task OnTimedEvent()
        {
            if (_tempoInicial < _tempoMaximo)
                Console.WriteLine($"Aguarde {_tempoInicial} segundos para iniciar uma nova busca...");
            else if (_tempoInicial == _tempoMaximo)
                await GetStocks();
            if (_tempoInicial <= 0)
                _tempoInicial = _tempoMaximo;
            else
                _tempoInicial--;
        }

        private async Task GetStocks()
        {
            try
            {
                var emailMessage = new MailMessage(_emailConfig.FromAddress.Address, _emailConfig.ToAddress.Address);

                var symbol = (Symbols)Enum.Parse(typeof(Symbols), _arguments.Ativo.ToUpper());
                var query = new StockQueryParams(1);
                var response = await _stockQuotesService.GetStockQuotes(symbol, query);

                var stocks = _mapper.Map(response);

                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("Cotações");
                Console.WriteLine($"Última atualização: {stocks.UltimaAtualizacao}");
                Console.WriteLine($"Data: {stocks.DataCompleta}");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                foreach (var cotacao in stocks.Dados)
                {
                    bool venda = false;

                    Console.WriteLine(cotacao.ToString());

                    if (cotacao.Preco >= _arguments.Maximo) venda = true;
                    if (cotacao.Preco <= _arguments.Minimo) venda = false;

                    emailMessage.Subject = venda == true ? $"Vender ativo {_arguments.Ativo}" : $"Compar ativo {_arguments.Ativo}";
                    emailMessage.Body = $@"Cotação atual para {_arguments.Ativo}{Environment.NewLine}{Environment.NewLine}{cotacao.ToString()}";

                    Console.WriteLine(venda == true ? "Enviando e-mail para venda" : "Enviando e-mail para compra");
                    await _emailService.Send(emailMessage);

                    Console.WriteLine("-----------------------------------------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine();
            }
        }
    }

}
