using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Plat {
    public static class MailProviderFactory {
        public static IMailProvider CreateMailProvider(ProviderEnum providerEnum)
        {
            switch (providerEnum)
            {
                case ProviderEnum.Smpt:
                    return new SmtpMailProvider();
                case ProviderEnum.EuroMessage:
                    return new EuroMessageMailProvider();
                case ProviderEnum.SendGrid:
                    return new SendGridMailProvider();
                default:
                    throw new ArgumentOutOfRangeException(nameof(providerEnum), providerEnum, null);
            }
        }
    }

    public  enum ProviderEnum
    {
        Smpt=1,EuroMessage=2,SendGrid=3
    }
}
