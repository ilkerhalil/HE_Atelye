using CommonMailLibrary.Interfaces;
using FakeItEasy;
using Shouldly;
using Xunit;

namespace HE_Atelye_CommonMailLibrary.Tests {
    public class MailRequestValidatorTest {
        private MailRequest _fakeMailRequest;
        private MailRequestValidator _fakeMailRequestValidator;

        [Fact]
        public void Validate_Null_Test() {
            
            _fakeMailRequestValidator = A.Fake<MailRequestValidator>(options => options.WithArgumentsForConstructor(new object[] { null }
            ));
            Should.Throw<MailRequestValidationException>(() => _fakeMailRequestValidator.Validate()).Message.ShouldBe("MailRequest is null");
        }

        [Fact]
        public void Validate_To_Test() {
            _fakeMailRequest = A.Fake<MailRequest>(options => options.ConfigureFake(request => request.From = "ozan.cakin@gmail.com"));
            _fakeMailRequestValidator = A.Fake<MailRequestValidator>(options => options.WithArgumentsForConstructor(new object[] { _fakeMailRequest }
            ));
            Should.Throw<MailRequestValidationException>(() => _fakeMailRequestValidator.Validate()).Message.ShouldBe("MailRequest (To) must be fill");
        }
        [Fact]
        public void Validate_From_Test() {
            _fakeMailRequest = A.Fake<MailRequest>(options => options.ConfigureFake(request => {
                request.Body = "Merhaba Dünya";
                request.To.Add(new MailAddress("ilkerhalil@gmail.com"));
            }

            ));
            _fakeMailRequestValidator = A.Fake<MailRequestValidator>(options => options.WithArgumentsForConstructor(new object[] { _fakeMailRequest }
            ));
            Should.Throw<MailRequestValidationException>(() => _fakeMailRequestValidator.Validate()).Message.ShouldBe("MailRequest (From) must be fill");
        }

    }
}