using AutoFixture;
using Cotacao.Adapter.Adapters;
using Cotacao.Adapter.Interfaces.Adapter;
using Cotacao.Adapter.Interfaces.Email;
using Moq;
using NUnit.Framework;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Cotacao.Testes.Unitarios.Adapter
{
    [TestFixture]
    public class EmailAdapterTest
    {
        private IFixture fixture;
        private IEmailAdapter adapter;
        private Mock<ISmtpClient> smtpClient;


        [OneTimeSetUp]
        public void Setup()
        {
            fixture = new Fixture();

            smtpClient = new Mock<ISmtpClient>();
            smtpClient.Setup(x => x.SendMailAsync(It.IsAny<MailMessage>())).Returns(Task.CompletedTask);

            adapter = new EmailAdapter(smtpClient.Object);
        }

        [Test]
        public void DeveSerPossivelEviarEmail()
        {
            Assert.DoesNotThrowAsync(async () => await adapter.Send(fixture.Create<MailMessage>()));
        }
    }
}
