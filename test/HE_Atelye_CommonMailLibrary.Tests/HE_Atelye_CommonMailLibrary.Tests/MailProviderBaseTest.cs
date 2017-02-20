using CommonMailLibrary.Interfaces;
using FakeItEasy;
using Xunit;

namespace HE_Atelye_CommonMailLibrary.Tests {

    public class MailProviderBaseTest {
        private readonly MailProviderBase _mailProviderBase;

        public MailProviderBaseTest() {
            _mailProviderBase = A.Fake<MailProviderBase>();
        }

        [Fact]
        public void Send_Email_Test() {
            var mailRequest = A.Fake<MailRequest>();
            _mailProviderBase.SendMail(mailRequest);
        }

        [Fact]
        public async void Send_Async_Email_Test() {
            var mailRequest = A.Fake<MailRequest>();
            await _mailProviderBase.SendMailAsync(mailRequest);
        }

    }
}