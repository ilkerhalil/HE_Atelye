using System.Threading.Tasks;

namespace MailProviders {
    public interface IMailProvider {

        void SendMail(MailRequest mailRequest);
        Task SendMailAsync(MailRequest mailRequest);
    }
}
