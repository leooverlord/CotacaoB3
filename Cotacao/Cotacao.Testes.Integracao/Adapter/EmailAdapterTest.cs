using Autofac;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Email;
using NUnit.Framework;
using System.Net.Mail;

namespace Cotacao.Testes.Integracao.Adapter
{
    [TestFixture]
    public class EmailAdapterTest : SetupIntegracao
    {
        private IEmailAdapter adapter;
        private IEmailConfig emailConfig;

        [OneTimeSetUp]
        public void Setup()
        {
            adapter = Container.Resolve<IEmailAdapter>();
            emailConfig = Container.Resolve<IEmailConfig>();
        }

        [Test]
        public void DeveSerPossivelEviarEmail()
        {
            var message = new MailMessage(emailConfig.FromAddress.Address, emailConfig.ToAddress.Address)
            {
                Subject = "Assunto",
                Body = "Mensagem Adapter",
            };

            Assert.DoesNotThrowAsync(async () => await adapter.Send(message));
        }
    }
}
