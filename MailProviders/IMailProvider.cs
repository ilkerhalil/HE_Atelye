using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailProviders
{
    public interface IMailProvider
    {
        void SendMail(string from, string to, string cc, string bcc, string subject, string body);
        Task SendMailAsync(string from, string to, string cc, string bcc, string subject, string body);
    }
}
