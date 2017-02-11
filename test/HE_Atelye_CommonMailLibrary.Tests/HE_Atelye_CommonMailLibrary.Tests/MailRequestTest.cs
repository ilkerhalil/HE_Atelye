using System;
using CommonMailLibrary.Interfaces;
using Should;
using Xunit;

namespace HE_Atelye_CommonMailLibrary.Tests {
    public class MailRequestTest {
        private readonly MailRequest mailRequest;

        public MailRequestTest() {
            mailRequest = FakeItEasy.A.Fake<MailRequest>(options => options.ConfigureFake(request =>
            {
                request.Subject = string.Empty;
                request.Body = string.Empty;
                request.From = string.Empty;
                
            }));
        }

        [Fact]
        public void MailRequest_Properties_Test() {
            //assert
            mailRequest.Subject.ShouldBeType<string>();
            mailRequest.Body.ShouldBeType<string>();
            mailRequest.From.ShouldBeType<string>();
            mailRequest.Bcc.ShouldBeType<MailAddressCollection>();
            mailRequest.Cc.ShouldBeType<MailAddressCollection>();
            mailRequest.To.ShouldBeType<MailAddressCollection>();
        }
    }
}
