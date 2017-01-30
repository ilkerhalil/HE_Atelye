using System;

namespace Reflection_Plat
{
    public class SendGridMailProvider : IMailProvider
    {
        public void SendEmail(string @from, string to, string cc, string bcc, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}