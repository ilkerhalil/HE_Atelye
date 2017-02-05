using System.Configuration;

namespace SendGridMailProvicer.ConfigSections {
    public class SendGridProviderConfigSection : ConfigurationSection {

        public SendGridProviderConfigElement SendGridProviderConfig {
            get { return this["SendGridProviderConfig"] as SendGridProviderConfigElement; }
            set { this["SendGridProviderConfig"] = value; }
        }
    }
}