namespace CommonMailLibrary.Interfaces {
    public class MailRequestValidator {
        private readonly MailRequest _request;

        public MailRequestValidator(MailRequest request) {
            _request = request;
        }

        public void Validate() {
            if (_request == null)
                throw new MailRequestValidationException("MailRequest is null");

            if (_request.To == null || _request.To.Count == 0)
                throw new MailRequestValidationException("MailRequest (To) must be fill");

            if (string.IsNullOrEmpty(_request.From))
                throw new MailRequestValidationException("MailRequest (From) must be fill");
        }
    }
}