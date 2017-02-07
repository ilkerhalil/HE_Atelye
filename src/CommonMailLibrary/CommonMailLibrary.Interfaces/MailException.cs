using System;

namespace CommonMailLibrary.Interfaces {

    public class MailException : Exception {
        public MailException() {

        }

        public MailException(string message) : base(message) {
        }

    }
}