using System.Configuration;

namespace SmtpMailProvider.ConfigSections
{
    public class SmtpProviderConfigSection : ConfigurationSection
    {
        public SmtpProviderConfigElement SmtpProviderConfig
        {
            get { return this["SmtpProviderConfig"] as SmtpProviderConfigElement; }
            set { this["SmtpProviderConfig"] = value; }
        }
    }
}
