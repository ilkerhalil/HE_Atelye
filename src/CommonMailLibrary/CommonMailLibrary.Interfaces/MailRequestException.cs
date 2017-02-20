namespace CommonMailLibrary.Interfaces
{
    public class MailRequestValidationException : MailException {
        public MailRequestValidationException(string message)
            :base(message)
        {
            
        }
    }
}