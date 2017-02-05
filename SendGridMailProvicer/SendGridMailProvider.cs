using System;
using System.Configuration;
using System.Threading.Tasks;
using MailProviders;
using SendGrid;
using SendGrid.Helpers.Mail;
using SendGridMailProvicer.ConfigSections;

namespace SendGridMailProvicer {
    public class SendGridMailProvider : IMailProvider {
        private const string MailType = "text/plain";
        private readonly string _apiKey;
        private SendGridAPIClient _sendGridApi;

        public SendGridMailProvider() {
            var sendGridProviderConfigSection = ConfigurationManager.GetSection("SendGridProviderConfigSection") as SendGridProviderConfigSection;
            if (sendGridProviderConfigSection != null) {
                _apiKey = sendGridProviderConfigSection.SendGridProviderConfig.SendGridApiKey;
            }
        }

        public SendGridMailProvider(string apiKey) {
            _apiKey = apiKey;
        }

        public async Task SendMailAsync(MailRequest request) {
            var mail = CreateMail(request);
            await _sendGridApi.client.mail.send.post(requestBody: mail.Get());
        }

        private Mail CreateMail(MailRequest request) {
            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new ArgumentNullException(nameof(_apiKey));
            _sendGridApi = new SendGridAPIClient(_apiKey);
            var mail = new Mail(new Email(request.From), request.Subject, new Email(request.To), new Content(MailType, request.Body));
            return mail;
        }

        public void SendMail(MailRequest request) {
            var mail = CreateMail(request);
            _sendGridApi.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
