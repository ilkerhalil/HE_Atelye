using System;
using System.Text.RegularExpressions;

namespace CommonMailLibrary.Interfaces {
    public class MailAddress {
        private string _displayName;
        private string _email;

        private const string RegEx = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";

        public MailAddress(string email) {
            if (!Regex.IsMatch(email, RegEx)) {
                throw new ArgumentException(nameof(email));
            }
            _email = email;
            _displayName = email;
        }

        public MailAddress(string displayName, string email)
            : this(email) {
            _displayName = displayName;
        }
    }
}