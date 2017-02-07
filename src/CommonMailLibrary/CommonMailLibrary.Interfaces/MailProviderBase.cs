using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonMailLibrary.Interfaces {
    public abstract class MailProviderBase : IMailProvider {

        public virtual void SendEmail(IEnumerable<MailRequest> mailRequests) {
            foreach (var mailRequest in mailRequests) {
                SendMail(mailRequest);
            }
        }

        public virtual void SendMail(MailRequest mailRequest) {
            var mailRequestValidator = new MailRequestValidator(mailRequest);
            mailRequestValidator.Validate();
            SendMailInternal(mailRequest);
        }

        public virtual async Task SendMailAsync(MailRequest mailRequest)
        {
            var mailRequestValidator = new MailRequestValidator(mailRequest);
            await SendMailAsyncInternal(mailRequest);
        }

        protected abstract Task SendMailAsyncInternal(MailRequest mailRequest);

        protected abstract void SendMailInternal(MailRequest mailRequest);


    }
}