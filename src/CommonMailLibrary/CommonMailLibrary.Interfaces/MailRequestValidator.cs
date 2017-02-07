namespace CommonMailLibrary.Interfaces {
    internal class MailRequestValidator {
        private readonly MailRequest _request;

        public MailRequestValidator(MailRequest request) {
            _request = request;
        }

        public void Validate() {
            if (_request == null)
                throw new MailRequestException("MailRequest is not null");
           
        }
    }
}