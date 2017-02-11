using System;
using System.ComponentModel;
using System.Configuration;

namespace CommonMailLibrary.Factory {
    public class MailProviderFactoryElement : ConfigurationElement {

        public string Name {
            get { return this["Name"] as string; }
            set { this["Name"] = value; }
        }

        //[TypeNameConverter()]
        [TypeConverter(typeof(TypeNameConverter))]
        public Type MailProviderType {
            get { return this["MailProviderType"] as Type;}
            set { this["MailProviderType"] = value; }
        }
    }
}
