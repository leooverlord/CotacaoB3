using Cotacao.Service.Interfaces;
using Cotacao.Service.IocConfig;
using Cotacao.Service.Models;
using System;
using System.Globalization;
using Topshelf;
using Topshelf.Autofac;

namespace Cotacao.Service
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Teste
            args = new string[3];
            args[0] = "petr4.sa";
            args[1] = "22.67";
            args[2] = "22.59";

            if(args.Length > 0)
            {
                var symbol = args[0];
                var high = float.Parse(args[1], CultureInfo.InvariantCulture.NumberFormat);
                var low = float.Parse(args[2], CultureInfo.InvariantCulture.NumberFormat);

                var arguments = new StockQuotesArguments(symbol, high, low);

                var container = DependencyContainer.GetContainer();

                HostFactory.Run(x =>
                {
                    x.UseAutofacContainer(container);

                    x.Service<IStockQuotesWinService>(config =>
                    {
                        config.ConstructUsingAutofacContainer();
                        config.WhenStarted(s => s.Start(arguments));
                        config.WhenStopped(s => s.Stop());
                    });


                    //x.RunAsLocalService();
                    x.SetServiceName("Serviço de cotações B3");
                    x.SetDescription("Serviço de cotações B3");
                    x.SetDisplayName("Serviço de cotações B3");
                    //x.StartAutomatically();
                });
            }
            else
            {
                Console.WriteLine("Por favor informe os argumentos para realizar a cotação!");
                Console.WriteLine("Símbolo, Alta e Baixa");
            }
            
        }
    }
}
