using Autofac;
using Cotacao.Application.Interfaces;
using Cotacao.Application.Services;

namespace Cotacao.Application.Modules
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StockQuotesService>().As<IStockQuotesService>().InstancePerLifetimeScope();
        }
    }
}
