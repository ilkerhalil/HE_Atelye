using System;
using CommonMailLibrary.Interfaces;

namespace CommonMailLibrary.Factory
{
    public class MailProviderFactoryException : MailException {
        public MailProviderFactoryException(string thisConfigurationEmpty)
            : base(thisConfigurationEmpty) {

        }
    }
}