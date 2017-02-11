using System;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using CommonMailLibrary.Interfaces;
using CommonMailLibrary.SmtpMailProvider.ConfigSections;

namespace CommonMailLibrary.SmtpMailProvider
{
    public class SmtpMailProvider : MailProviderBase
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

        private MailMessage Map(MailRequest mailRequest)
        {
            if (mailRequest == null)
            {
                throw new ArgumentNullException(nameof(mailRequest));
            }

            var mailMessage = new MailMessage();

            if (string.IsNullOrWhiteSpace(mailRequest.From))
                throw new ArgumentNullException(nameof(mailRequest.From));

            if (string.IsNullOrWhiteSpace(mailRequest.To.ToString()))
                throw new ArgumentNullException(nameof(mailRequest.To));

            if (mailRequest.Bcc.Count > 0)
                foreach (var item in mailRequest.Bcc)
                {
                    mailMessage.Bcc.Add(item.ToString());
                }

            if (mailRequest.Cc.Count > 0)
                foreach (var item in mailRequest.Cc)
                {
                    mailMessage.CC.Add(item.ToString());
                }

            foreach (var emailAddress in mailRequest.To)
            {
                mailMessage.To.Add(emailAddress.ToString());
            }

            mailMessage.From = new System.Net.Mail.MailAddress(mailRequest.From);



            _smtpClient = new SmtpClient(_smtpHost, _smtpPort)
            {
                EnableSsl = _smtpEnableSsl,
                Timeout = _smtpTimeOut
            };

            return mailMessage;
        }


        protected override async Task SendMailAsyncInternal(MailRequest mailRequest)
        {
            await _smtpClient.SendMailAsync(Map(mailRequest));
        }

        protected override void SendMailInternal(MailRequest mailRequest)
        {
            _smtpClient.Send(Map(mailRequest));
        }

        protected override void DisposeInternal()
        {
            if (_smtpClient != null)
            {
                _smtpClient = null;
            }
        }
    }
}
