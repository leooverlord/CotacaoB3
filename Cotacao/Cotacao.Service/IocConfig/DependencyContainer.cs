using Autofac;
using Cotacao.Adapter.Modules;
using Cotacao.Application.Modules;
using Cotacao.Service.Interfaces;
using Cotacao.Service.Services;
using Microsoft.Extensions.Configuration;

namespace Cotacao.Service.IocConfig
{
    public class DependencyContainer
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Configuration
            builder.Register<IConfiguration>(x => configuration);

            //Adapter
            builder.RegisterModule(new AdapterModule(configuration));

            //Application
            builder.RegisterModule(new ApplicationModule());

            //WinServices
            builder.RegisterType<StockQuotesWinService>().As<IStockQuotesWinService>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
