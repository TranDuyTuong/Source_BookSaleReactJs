using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CommonConfiguration.SentEmailCommon
{
    public class SentEmail
    {
        /// <summary>
        /// SentEmailCommons
        /// </summary>
        /// <returns></returns>
        public bool SentEmailCommons(string emailFrom, string password, string emailTo, string body, string title ,string port, string host)
        {
            try
            {
                // Email Default 
                var smtpClient = new SmtpClient(host)
                {
                    Port = Convert.ToInt32(port),
                    Credentials = new NetworkCredential(emailFrom, password),
                    EnableSsl = true
                };

                // Content Email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailFrom),
                    Subject = title,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(emailTo);

                // Sent Email
                smtpClient.Send(mailMessage);
            }
            catch(Exception ex)
            {

            }
            return true;
        }

        public string CustomBodyEmail(string email, string nameUser, string typeEmail)
        {
            return "ok";
        }

        /// <summary>
        /// SentMailRegiterEmployee
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private string SentMailRegiterEmployee(string body)
        {
            return body;
        }

    }
}
