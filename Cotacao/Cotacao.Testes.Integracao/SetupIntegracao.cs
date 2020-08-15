using Autofac;
using Cotacao.Testes.Integracao.Ioc;
using NUnit.Framework;

namespace Cotacao.Testes.Integracao
{
    [TestFixture]
    public abstract class SetupIntegracao
    {
        protected IContainer Container;

        [OneTimeSetUp]
        public void SetupBase()
        {
            Container = DependencyContainer.GetContainer();
        }

    }
}
