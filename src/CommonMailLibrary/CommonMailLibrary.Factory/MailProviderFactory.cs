using System;
using System.Configuration;
using CommonMailLibrary.Interfaces;

namespace CommonMailLibrary.Factory {
    public static class MailProviderFactory {
        public static IMailProvider CreateMailProvider(string configurationSectionName) {
            var mailProviderFactorySection = ConfigurationManager.GetSection(configurationSectionName) as MailProviderFactorySection;
            if (mailProviderFactorySection != null) {
                return Activator.CreateInstance(mailProviderFactorySection.MailProviderFactory.MailProviderType) as IMailProvider;

            }
            throw new MailProviderFactoryException("this configuration empty");
        }

    }
}