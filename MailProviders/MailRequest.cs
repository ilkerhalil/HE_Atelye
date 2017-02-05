namespace MailProviders
{
    public class MailRequest {

        public string From { get; }

        public string To { get; }

        public string Cc { get; }

        public string Bcc { get; }

        public string Subject { get; }

        public string Body { get; }

        public MailRequest(string from, string to, string cc, string bcc, string subject, string body) {
            From = @from;
            To = to;
            Cc = cc;
            Bcc = bcc;
            Subject = subject;
            Body = body;
        }
    }
}