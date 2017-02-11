using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using CommonMailLibrary.Interfaces;
using CommonMailLibrary.SendGridMailProvider.ConfigSections;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CommonMailLibrary.SendGridMailProvider
{
    public class SendGridMailProvider : MailProviderBase
    {
        private const string MailType = "text/plain";
        private readonly string _apiKey;
        private SendGridAPIClient _sendGridApi;

        public SendGridMailProvider()
        {
            var sendGridProviderConfigSection = ConfigurationManager.GetSection("SendGridProviderConfigSection") as SendGridProviderConfigSection;
            if (sendGridProviderConfigSection != null)
            {
                _apiKey = sendGridProviderConfigSection.SendGridProviderConfig.SendGridApiKey;
            }
        }

        public SendGridMailProvider(string apiKey)
        {
            _apiKey = apiKey;
        }

        protected override async Task SendMailAsyncInternal(MailRequest mailRequest)
        {
            var mail = Map(mailRequest);
            await _sendGridApi.client.mail.send.post(requestBody: mail.Get());
        }

        protected override void SendMailInternal(MailRequest mailRequest)
        {
            var mail = Map(mailRequest);
            _sendGridApi.client.mail.send.post(requestBody: mail.Get());
        }

        protected override void DisposeInternal()
        {
            if (_sendGridApi != null)
            {
                _sendGridApi = null;
            }
        }

        private Mail Map(MailRequest request)
        {
            var mail = new Mail();
            var personalization = new Personalization();

            if (string.IsNullOrWhiteSpace(_apiKey))
                throw new ArgumentNullException(nameof(_apiKey));

            _sendGridApi = new SendGridAPIClient(_apiKey);

            foreach (var mailAddress in request.To)
            {
                personalization.Tos.Add(new Email(mailAddress.ToString()));
            }

            foreach (var bccAddress in request.Bcc)
            {
                personalization.Bccs.Add(new Email(bccAddress.ToString()));
            }

            foreach (var ccAddress in request.Cc)
            {
                personalization.AddCc(new Email(ccAddress.ToString()));
            }

            mail.AddPersonalization(personalization);
            mail.Subject = request.Subject;
            return mail;
        }
    }
}
