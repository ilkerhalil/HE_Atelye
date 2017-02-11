using System;
using System.Threading.Tasks;

namespace CommonMailLibrary.Interfaces
{
    public interface IMailProvider : IDisposable
    {

        void SendMail(MailRequest mailRequest);
        Task SendMailAsync(MailRequest mailRequest);
    }
}
