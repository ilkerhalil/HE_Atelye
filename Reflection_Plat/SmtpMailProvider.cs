using System;

namespace Reflection_Plat
{
    public class SmtpMailProvider : IMailProvider
    {
        //todo:smtp protokulune göre mail atacak sınıf implement edilecek..!
        public void SendEmail(string @from, string to, string cc, string bcc, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}