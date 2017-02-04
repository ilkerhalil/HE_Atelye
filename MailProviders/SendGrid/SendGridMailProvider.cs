using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;

namespace MailProviders.SendGrid
{
    public class SendGridMailProvider : IMailProvider
    {
        private readonly string _apiKey;
        private SendGridAPIClient _sendGridApi;

        public SendGridMailProvider()
        {
            _apiKey = ConfigurationManager.AppSettings["SendGridApiKey"];
            _sendGridApi = new SendGridAPIClient(_apiKey);
        }

        public async Task SendMailAsync(string @from, string to, string cc, string bcc, string subject, string body)
        {
            Mail mail = new Mail(new Email(from), subject, new Email(to), new Content("text/plain", body));

            await _sendGridApi.client.mail.send.post(requestBody: mail.Get());
        }

        public void SendMail(string @from, string to, string cc, string bcc, string subject, string body)
        {
            Mail mail = new Mail(new Email(from), subject, new Email(to), new Content("text/plain", body));

            _sendGridApi.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
