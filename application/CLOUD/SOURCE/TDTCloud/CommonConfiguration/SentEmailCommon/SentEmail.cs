using CodeFirtMigration.DataFE;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration.M_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace CommonConfiguration.SentEmailCommon
{
    public class SentEmail
    {
        private readonly ContextFE context;
        public SentEmail(ContextFE _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// Contructor
        /// </summary>
        public SentEmail() { }

        /// <summary>
        /// SentEmailCommons
        /// </summary>
        /// <returns></returns>
        public bool SentEmailCommons(string emailFrom, 
                                     string password, 
                                     string emailTo, 
                                     int typeEmail, 
                                     string title,
                                     string port, 
                                     string host, 
                                     string fullName)
        {
            bool result = false;
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
                var contentBody = CustomBodyEmail(fullName, typeEmail);

                if(contentBody.Status == true)
                {
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(emailFrom),
                        Subject = title,
                        Body = contentBody.Message,
                        IsBodyHtml = true
                    };
                    mailMessage.To.Add(emailTo);

                    // Sent Email
                    smtpClient.Send(mailMessage);
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            catch(Exception ex)
            {
                // save log error
                // Save log error
                var log = new Log()
                {
                    Id = new Guid(),
                    UserID = "Error System Common Function SentEmailCommons",
                    Message = "Exception is: " + ex.Message,
                    DateCreate = DateTime.Now
                };
                this.context.Add(log);
                this.context.SaveChanges();
                result = false;
            }
            return result;
        }

        public ReturnCommonApi CustomBodyEmail(string nameUser, int typeEmail)
        {
            var result = new ReturnCommonApi();
            try
            {
                // Get type Email in DB
                var queryEmail = this.context.emailTemplates.FirstOrDefault(x => x.TypeCode == typeEmail.ToString());

                if (queryEmail == null)
                {
                    result.Status = false;
                    result.IdPlugin = DataCommon.EventError;
                    result.Message = DataCommon.MessageNotFindTypeEmail;
                }
                else
                {
                    // Check TypeEmail
                    switch (typeEmail)
                    {
                        // email regiter
                        case var item when item == DataCommon.TypeRegiter:
                            result.Status = true;
                            result.IdPlugin = DataCommon.EventSuccess;
                            result.Message = "<h3 style=\"font-family: initial;\">" + queryEmail.TitleBody + " :" + nameUser + "</h3>"
                                            + queryEmail.ContentBody
                                            + queryEmail.Goodbye
                                            + queryEmail.TemSystem
                                            + DateTime.Now.Date
                                            + "<img style=\"width: 150px; margin: 10px 10px;\" src=\"https://duhocchaudaiduong.edu.vn/hinh-nen-dep-cute/imager_4692.jpg\"/>"
                                            + queryEmail.PhoneContact;
                            break;
                        default:
                            result.Status = false;
                            result.IdPlugin = DataCommon.EventError;
                            result.Message = DataCommon.MessageNotFindTypeEmail;
                            break;

                    }
                }
            }
            catch(Exception ex)
            {
                // Save log error
                var log = new Log()
                {
                    Id = new Guid(),
                    UserID = "Error System Common Function CustomBodyEmail",
                    Message = "Exception is: " + ex.Message,
                    DateCreate = DateTime.Now
                };
                result.Status = false;
                result.IdPlugin = DataCommon.EventError;
                result.Message = ex.Message;

                this.context.Add(log);
                this.context.SaveChanges();
            }
            return result;
        }

    }
}
