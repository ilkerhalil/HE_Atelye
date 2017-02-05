using System.Configuration;

namespace SendGridMailProvider.ConfigSections {

    public class SendGridProviderConfigElement : ConfigurationElement {

        [ConfigurationProperty("ApiKey")]
        public string SendGridApiKey {
            get { return this["ApiKey"] as string; }
            set { this["ApiKey"] = value; }
        }
    }
}
