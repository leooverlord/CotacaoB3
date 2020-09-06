using Autofac;
using Cotacao.Adapter.Modules;
using Cotacao.Application.Modules;
using Cotacao.Service.Interfaces;
using Cotacao.Service.Interfaces.Mappers;
using Cotacao.Service.Mappers;
using Cotacao.Service.Models;
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

            //Mappers
            builder.RegisterType<StockQuoteMapper>().As<IStockQuoteMapper>().InstancePerLifetimeScope();
            builder.RegisterType<StockDataMapper>().As<IStockDataMapper>().InstancePerLifetimeScope();

            //WinServices
            builder.RegisterType<StockQuotesWinService>().As<IStockQuotesWinService>().InstancePerLifetimeScope();

            //Arguments
            builder.Register(x => new StockQuotesArguments(Program.Ativo, Program.Maximo, Program.Minimo)).AsSelf().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
