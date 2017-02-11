namespace CommonMailLibrary.Interfaces
{
    internal class MailRequestValidator
    {
        private readonly MailRequest _request;

        public MailRequestValidator(MailRequest request)
        {
            _request = request;
        }

        public void Validate()
        {
            if (_request == null)
                throw new MailRequestException("MailRequest is null");

            if (_request.To == null || _request.To.Count == 0)
                throw new MailRequestException("MailRequest (To) must be fill");

            if (string.IsNullOrEmpty(_request.From))
                throw new MailRequestException("MailRequest (From) must be fill");
        }
    }
}