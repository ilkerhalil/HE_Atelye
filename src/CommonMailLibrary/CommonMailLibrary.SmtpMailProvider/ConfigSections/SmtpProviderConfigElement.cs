using System.Configuration;

namespace CommonMailLibrary.SmtpMailProvider.ConfigSections
{
    public class SmtpProviderConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("Host")]
        public string SmtpHost
        {
            get { return this["Host"] as string; }
            set { this["Host"] = value; }
        }

        [ConfigurationProperty("Port")]
        public int SmtpPort
        {
            get { return (int)this["Port"]; }
            set { this["Port"] = value; }
        }

        [ConfigurationProperty("EnableSsl")]
        public bool SmtpEnableSsl
        {
            get { return (bool)this["EnableSsl"]; }
            set { this["EnableSsl"] = value; }
        }

        [ConfigurationProperty("TimeOut")]
        public int SmtpTimeOut
        {
            get { return (int)this["TimeOut"]; }
            set { this["TimeOut"] = value; }
        }

    }
}
