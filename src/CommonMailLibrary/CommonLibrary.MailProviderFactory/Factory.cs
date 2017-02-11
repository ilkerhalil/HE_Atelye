using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMailLibrary.Interfaces;
using CommonMailLibrary.Interfaces.Enums;
using CommonMailLibrary.SendGridMailProvider;
using CommonMailLibrary.SmtpMailProvider;

namespace CommonLibrary.MailProviderFactory {
    public static class Factory {
        public static IMailProvider CreateMailProvider(MailProvider mailProvider) {
            switch (mailProvider) {
                case MailProvider.Smtp:
                    return new SmtpMailProvider();
                case MailProvider.EuroMessage:
                    throw new ArgumentOutOfRangeException(nameof(mailProvider), mailProvider, null);
                case MailProvider.SendGrid:
                    return new SendGridMailProvider();
                default:
                    throw new ArgumentOutOfRangeException(nameof(mailProvider), mailProvider, null);
            }
        }
    }
}
