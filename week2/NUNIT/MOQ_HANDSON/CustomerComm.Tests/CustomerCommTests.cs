using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> mockMailSender;
        private CustomerCommLib.CustomerComm customerComm;


        [OneTimeSetUp]
        public void Setup()
        {
            mockMailSender = new Mock<IMailSender>();
            mockMailSender.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            customerComm = new CustomerCommLib.CustomerComm(mockMailSender.Object);
        }

        [Test]
        public void SendMailToCustomer_WhenCalled_ReturnsTrue()
        {
            var result = customerComm.SendMailToCustomer();
            Assert.That(result, Is.True);
        }
    }
}
