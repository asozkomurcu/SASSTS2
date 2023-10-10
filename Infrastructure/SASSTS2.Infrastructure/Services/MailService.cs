using SASSTS2.Application.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SASSTS2.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
        {

            throw new NotImplementedException();
        }

        public Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos) 
                mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new("asozkmrc@yandex.com.tr")
        }
    }
}
