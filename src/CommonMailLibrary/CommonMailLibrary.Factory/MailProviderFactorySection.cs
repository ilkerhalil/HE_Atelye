using System.Configuration;

namespace CommonMailLibrary.Factory
{
    public class MailProviderFactorySection : ConfigurationSection {


        public MailProviderFactoryElement MailProviderFactory {
            get { return this["MailProviderFactory"] as MailProviderFactoryElement; }
            set { this["MailProviderFactory"] = value; }
        }
    }
}