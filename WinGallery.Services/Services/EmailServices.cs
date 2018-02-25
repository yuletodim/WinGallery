namespace WinGallery.Services.Services
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Interfaces;
    using Utils;

    public class EmailServices : IEmailServices
    {
        public async Task SendAsync(string email, string emailBody, string emailSubject)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.Subject = emailSubject;
                    mailMessage.Body = emailBody;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.From = new MailAddress("yuletodim.apps@gmail.com");
                    mailMessage.To.Add(new MailAddress(email));

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        var credentials = new NetworkCredential(Credentials.AppEmail, Credentials.EmailPass);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = credentials;
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;

                        await smtp.SendMailAsync(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
    }
}
