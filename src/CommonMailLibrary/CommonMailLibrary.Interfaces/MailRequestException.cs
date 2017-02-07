namespace CommonMailLibrary.Interfaces
{
    public class MailRequestException : MailException {
        public MailRequestException(string message)
            :base(message)
        {
            
        }
    }
}