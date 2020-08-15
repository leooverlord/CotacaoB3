using Autofac;
using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces;
using Cotacao.Adapter.Models.Config;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Net.Http;

namespace Cotacao.Adapter.Modules
{
    public class AdapterModule : Module
    {
        private readonly IConfiguration _configuration;
        public AdapterModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StockQuotesAdapter>().As<IStockQuotesAdapter>().InstancePerLifetimeScope();

            var apiConfig = _configuration.GetSection("HgBrasilApi").Get<ApiConfig>();

            builder.Register(c =>
            {
                var httpClient = new HttpClient() { BaseAddress = new Uri(apiConfig.BaseAdress) };
                return RestService.For<IStockQuotesServiceApi>(httpClient);
            }).As<IStockQuotesServiceApi>();
        }
    }
}
