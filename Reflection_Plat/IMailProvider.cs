using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Plat {
    public  interface IMailProvider
    {
        void SendEmail(string from, string to, string cc, string bcc,string subject, string body);
    }

    public class SendGridMailProvider : IMailProvider
    {
        public void SendEmail(string @from, string to, string cc, string bcc, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }


    public class EuroMessageMailProvider : IMailProvider
    {
        public void SendEmail(string @from, string to, string cc, string bcc, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }

    public class SmtpMailProvider : IMailProvider
    {
        public void SendEmail(string @from, string to, string cc, string bcc, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
