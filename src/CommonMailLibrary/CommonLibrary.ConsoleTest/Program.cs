using System.Data.SqlClient;
using CommonLibrary.MailProviderFactory;
using CommonMailLibrary.Interfaces;
using CommonMailLibrary.Interfaces.Enums;

namespace CommonLibrary.ConsoleTest {
    static class Program {
        static void Main(string[] args) {
            using (var mailProvider = Factory.CreateMailProvider(MailProvider.Smtp)) {
                mailProvider.SendMail(new MailRequest());
                
            }
          
        }
    }
}
