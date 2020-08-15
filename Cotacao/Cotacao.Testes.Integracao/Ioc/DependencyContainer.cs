using Autofac;
using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces;
using Cotacao.Adapter.Models.Config;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Net.Http;

namespace Cotacao.Testes.Integracao.Ioc
{
    public class DependencyContainer
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var apiConfig = configuration.GetSection("HgBrasilApi").Get<ApiConfig>();

            builder.Register<IConfiguration>(x => configuration);
            builder.RegisterType<StockQuotesAdapter>().As<IStockQuotesAdapter>().InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var httpClient = new HttpClient() { BaseAddress = new Uri(apiConfig.BaseAdress) };
                return RestService.For<IStockQuotesServiceApi>(httpClient);
            }).As<IStockQuotesServiceApi>();


            return builder.Build();
        }
    }
}
