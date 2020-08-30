using Autofac;
using Cotacao.Adapter.Interfaces.Email;
using Cotacao.Application.Interfaces;
using NUnit.Framework;
using System.Net.Mail;

namespace Cotacao.Testes.Integracao.Application
{
    [TestFixture]
    public class EmailServiceTest : SetupIntegracao
    {
        private IEmailService service;
        private IEmailConfig emailConfig;

        [OneTimeSetUp]
        public void Setup()
        {
            service = Container.Resolve<IEmailService>();
            emailConfig = Container.Resolve<IEmailConfig>();
        }

        [Test]
        public void DeveSerPossivelEnviarEmail()
        {
            var message = new MailMessage(emailConfig.FromAddress.Address, emailConfig.ToAddress.Address)
            {
                Subject = "Assunto",
                Body = "Mensagem Service",
            };

            Assert.DoesNotThrowAsync(async () => await service.Send(message));
        }
    }
}
