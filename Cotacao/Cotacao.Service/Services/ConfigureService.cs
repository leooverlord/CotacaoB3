using Autofac;
using Cotacao.Service.Interfaces;
using Cotacao.Service.IocConfig;
using Cotacao.Service.Models;
using System.Globalization;
using Topshelf;
using Topshelf.Autofac;

namespace Cotacao.Service.Services
{
    internal class ConfigureService
    {
        internal static void Configure()
        {
            var container = DependencyContainer.GetContainer();

            HostFactory.Run(x =>
            {
                var args = container.Resolve<StockQuotesArguments>();

                x.UseAutofacContainer(container);

                x.Service<IStockQuotesWinService>(config =>
                {
                    config.ConstructUsingAutofacContainer();
                    config.WhenStarted(s => s.Start());
                    config.WhenStopped(s => s.Stop());
                });

                x.SetServiceName("Serviço de Cotação B3");
                x.SetDescription("Serviço de Cotação B3");
                x.SetDisplayName("Serviço de Cotação B3");
                x.AddCommandLineDefinition("ativo", x => args.Ativo = x);
                x.AddCommandLineDefinition("maximo", x => args.Maximo = double.Parse(x, CultureInfo.InvariantCulture.NumberFormat));
                x.AddCommandLineDefinition("minimo", x => args.Minimo = double.Parse(x, CultureInfo.InvariantCulture.NumberFormat));
            });
        }
    }
}
