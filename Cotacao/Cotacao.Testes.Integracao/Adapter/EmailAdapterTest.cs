using Autofac;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Models.Config;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Net.Mail;

namespace Cotacao.Testes.Integracao.Adapter
{
    [TestFixture]
    public class EmailAdapterTest : SetupIntegracao
    {
        private IEmailAdapter adapter;
        private IConfiguration configuration;

        [OneTimeSetUp]
        public void Setup()
        {
            adapter = Container.Resolve<IEmailAdapter>();
            configuration = Container.Resolve<IConfiguration>();
        }

        [Test]
        public void DeveSerPossivelEviarEmail()
        {
            var email = configuration.GetSection("Email").Get<EmailConfig>();

            var message = new MailMessage(email.FromAddress.Address, email.ToAddress.Address)
            {
                Subject = "Assunto",
                Body = "Mensagem",
            };
            
            Assert.DoesNotThrowAsync(async () => await adapter.Send(message));
        }
    }
}
