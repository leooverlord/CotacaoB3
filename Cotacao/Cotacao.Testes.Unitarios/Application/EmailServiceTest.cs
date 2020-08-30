using AutoFixture;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Application.Services;
using Moq;
using NUnit.Framework;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Testes.Unitarios.Application
{
    [TestFixture]
    public class EmailServiceTest
    {
        private EmailService service;
        private Mock<IEmailAdapter> adapter;
        private MailMessage message;

        [OneTimeSetUp]
        public void Setup()
        {
            var fixture = new Fixture();
            message = fixture.Create<MailMessage>();

            adapter = new Mock<IEmailAdapter>();
            adapter.Setup(x => x.Send(It.IsAny<MailMessage>())).Returns(Task.CompletedTask);

            service = new EmailService(adapter.Object);
        }

        [Test]
        public void DeveSerPossivelEnviarEmail()
        {
            Assert.DoesNotThrowAsync(async () => await service.Send(message));
        }
    }
}
