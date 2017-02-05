using System.Configuration;

namespace SendGridMailProvider.ConfigSections {
    public class SendGridProviderConfigSection : ConfigurationSection {

        public SendGridProviderConfigElement SendGridProviderConfig {
            get { return this["SendGridProviderConfig"] as SendGridProviderConfigElement; }
            set { this["SendGridProviderConfig"] = value; }
        }
    }
}