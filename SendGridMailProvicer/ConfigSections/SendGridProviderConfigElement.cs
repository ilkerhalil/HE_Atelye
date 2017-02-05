using System.Configuration;

namespace SendGridMailProvicer.ConfigSections {

    public class SendGridProviderConfigElement : ConfigurationElement {

        [ConfigurationProperty("ApiKey")]
        public string SendGridApiKey {
            get { return this["ApiKey"] as string; }
            set { this["ApiKey"] = value; }
        }
    }
}
