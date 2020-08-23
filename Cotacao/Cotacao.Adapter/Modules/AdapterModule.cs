using Autofac;
using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Api;
using Cotacao.Adapter.Interfaces.Email;
using Cotacao.Adapter.Models.Config;
using Cotacao.Adapter.Wrapper;
using Microsoft.Extensions.Configuration;
using Refit;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

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
            var api = _configuration.GetSection("Api").Get<ApiConfig>();
            var email = _configuration.GetSection("Email").Get<EmailConfig>();

            //Adapter
            builder.RegisterType<StockQuotesAdapter>().As<IStockQuotesAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<EmailAdapter>().As<IEmailAdapter>().InstancePerLifetimeScope();
            builder.RegisterType<EmailAdapter>().As<IEmailAdapter>().InstancePerLifetimeScope();

            #region MyRegion
            //Api
            builder.Register(x => new ApiConfig
            {
                BaseAdress = api.BaseAdress,
                Headers = api.Headers
            }).As<IApiConfig>().InstancePerLifetimeScope();

            builder.Register(c =>
            {
                var httpClient = new HttpClient() { BaseAddress = new Uri(api.BaseAdress) };
                api.Headers.ForEach(header => httpClient.DefaultRequestHeaders.Add(header.Key, header.Value));
                return RestService.For<IStockQuotesServiceApi>(httpClient);
            }).As<IStockQuotesServiceApi>(); 
            #endregion

            //Email
            builder.Register(x => new EmailConfig
            {
                FromAddress = email.FromAddress,
                ToAddress = email.ToAddress,
                Smtp = email.Smtp
            })
            .As<IEmailConfig>().InstancePerLifetimeScope();

            builder.Register(x => new SmtpClient
            {
                Host = email.Smtp.Host,
                Port = email.Smtp.Port,
                EnableSsl = email.Smtp.EnableSsl,
                DeliveryMethod = email.Smtp.DeliveryMethod,
                UseDefaultCredentials = email.Smtp.UseDefaultCredentials,
                Credentials = new NetworkCredential(email.FromAddress.Address, email.FromAddress.Password)
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<SmtpClientWrapper>().As<ISmtpClient>().InstancePerLifetimeScope();



        }
    }
}
