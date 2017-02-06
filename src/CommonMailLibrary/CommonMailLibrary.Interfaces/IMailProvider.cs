using System.Threading.Tasks;

namespace CommonMailLibrary.Interfaces {
    public interface IMailProvider {

        void SendMail(MailRequest mailRequest);
        Task SendMailAsync(MailRequest mailRequest);
    }
}
