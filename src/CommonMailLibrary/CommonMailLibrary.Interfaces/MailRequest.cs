namespace CommonMailLibrary.Interfaces {

    public class MailRequest {

        public MailRequest() {
            To = new MailAddressCollection();
            Cc = new MailAddressCollection();
            Bcc = new MailAddressCollection();
        }
        public MailRequest(string from, string to)
            : this() {
            From = @from;
            To.Add(new MailAddress(to));
        }

        public string From { get; set; }

        public MailAddressCollection To { get; }

        public MailAddressCollection Cc { get; }

        public MailAddressCollection Bcc { get; }

        public string Subject { get; set; }

        public string Body { get; set; }

        
    }
}