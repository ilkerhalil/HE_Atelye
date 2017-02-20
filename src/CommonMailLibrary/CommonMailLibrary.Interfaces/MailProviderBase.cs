using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommonMailLibrary.Interfaces
{
    public abstract class MailProviderBase : IMailProvider
    {

        public virtual void SendMail(IEnumerable<MailRequest> mailRequests)
        {
            foreach (var mailRequest in mailRequests)
            {
                SendMail(mailRequest);
            }
        }

        public virtual void SendMail(MailRequest mailRequest)
        {
            Validate(mailRequest);

            SendMailInternal(mailRequest);
        }

        public virtual async Task SendMailAsync(MailRequest mailRequest)
        {
            Validate(mailRequest);

            await SendMailAsyncInternal(mailRequest);

        }

        private void Validate(MailRequest mailRequest)
        {
            var mailRequestValidator = new MailRequestValidator(mailRequest);

            mailRequestValidator.Validate();
        }
        public void Dispose()
        {
            DisposeInternal();
            GC.SuppressFinalize(this);
        }

        protected abstract Task SendMailAsyncInternal(MailRequest mailRequest);

        protected abstract void SendMailInternal(MailRequest mailRequest);
        protected abstract void DisposeInternal();

        

    }
}