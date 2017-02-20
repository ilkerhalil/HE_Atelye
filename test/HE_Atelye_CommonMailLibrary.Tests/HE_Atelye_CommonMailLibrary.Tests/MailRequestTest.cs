using System;
using CommonMailLibrary.Interfaces;

using Shouldly;
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
            mailRequest.Subject.ShouldBeOfType<string>();
            mailRequest.Body.ShouldBeOfType<string>();
            mailRequest.From.ShouldBeOfType<string>();
            mailRequest.Bcc.ShouldBeOfType<MailAddressCollection>();
            mailRequest.Cc.ShouldBeOfType<MailAddressCollection>();
            mailRequest.To.ShouldBeOfType<MailAddressCollection>();
        }
    }
}
