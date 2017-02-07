using System;
using System.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using CommonMailLibrary.Interfaces;
using CommonMailLibrary.SmtpMailProvider.ConfigSections;

namespace CommonMailLibrary.SmtpMailProvider
{
    public class SmtpMailProvider : IMailProvider
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly bool _smtpEnableSsl;
        private readonly int _smtpTimeOut;
        private SmtpClient _smtpClient;

        public SmtpMailProvider(string smtpHost, int smtpPort, bool smtpEnableSsl = false, int smtpTimeOut = 200)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _smtpEnableSsl = smtpEnableSsl;
            _smtpTimeOut = smtpTimeOut;
        }

        public SmtpMailProvider()
        {
            var smtpProviderConfigSection = ConfigurationManager.GetSection("SmtpProviderConfigSection") as SmtpProviderConfigSection;

            if (smtpProviderConfigSection == null)
                throw new ArgumentNullException(nameof(smtpProviderConfigSection));

            _smtpHost = smtpProviderConfigSection.SmtpProviderConfig.SmtpHost;
            _smtpPort = smtpProviderConfigSection.SmtpProviderConfig.SmtpPort;
            _smtpEnableSsl = smtpProviderConfigSection.SmtpProviderConfig.SmtpEnableSsl;
            _smtpTimeOut = smtpProviderConfigSection.SmtpProviderConfig.SmtpTimeOut;
        }

        private MailMessage CreateMail(MailRequest mailRequest)
        {
            if (mailRequest == null)
            {
                throw new ArgumentNullException(nameof(mailRequest));
            }

            var mailMessage = new MailMessage();

            if (string.IsNullOrWhiteSpace(mailRequest.From))
                throw new ArgumentNullException(nameof(mailRequest.From));

            if (string.IsNullOrWhiteSpace(mailRequest.To))
                throw new ArgumentNullException(nameof(mailRequest.To));

            if (!string.IsNullOrWhiteSpace(mailRequest.Bcc))
                mailMessage.Bcc.Add(mailRequest.Bcc);

            if (!string.IsNullOrWhiteSpace(mailRequest.Cc))
                mailMessage.CC.Add(mailRequest.Cc);

            mailMessage.To.Add(mailRequest.To);
            mailMessage.From = mailMessage.From;


            _smtpClient = new SmtpClient(_smtpHost, _smtpPort)
            {
                EnableSsl = _smtpEnableSsl,
                Timeout = _smtpTimeOut
            };

            return mailMessage;
        }

        public void SendMail(MailRequest mailRequest)
        {
            var mailMessage = CreateMail(mailRequest);
            _smtpClient.Send(mailMessage);
        }

        public async Task SendMailAsync(MailRequest mailRequest)
        {
            var mailMessage = CreateMail(mailRequest);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
