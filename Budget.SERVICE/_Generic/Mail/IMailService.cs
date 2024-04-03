using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Budget.SERVICE
{
    public interface IMailService
    {
        //void SendMailAsync();

        //Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailAsync(string email,string name, string subject, string message);
    }
}
