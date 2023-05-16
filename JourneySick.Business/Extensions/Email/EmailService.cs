/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;

namespace RevenueSharingInvest.Business.Services.Extensions.Email
{
    public static class EmailService
    {
        //private static readonly string App_Password = "hchr lwct gcor qtsr";
        private static readonly string APP_PASSWORD = "ymvbgzvhhuzgiswo";
        private static readonly string SENDER = "journeysick.noreply@gmail.com";
        public static async Task SendEmail(string receiver)
        {
            string SendMailSubject = "JourneySick - Invitation To Another Journey!!!";
            string SendMailBody = "ok";

            try
            {
                SmtpClient SmtpServer = new("smtp.gmail.com", 587)
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Timeout = 5000,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(SENDER, APP_PASSWORD)
                };

                MailMessage email = new()
                {
                    // START
                    From = new MailAddress(SENDER),
                    Subject = SendMailSubject,
                };


                string emailHTML = GetEmailTemplate();
                emailHTML = emailHTML.Replace("[KrowdInvestorName]", investorName);
                emailHTML = emailHTML.Replace("[KrowdProjectName]", projectName);
                emailHTML = emailHTML.Replace("[FileContractChecksum]", fileChecksum[0]);


                email.Body = emailHTML;

                email.To.Add(receiver);
                email.CC.Add(SENDER);

                email.IsBodyHtml = true;

                SmtpServer.Send(email);

                SmtpServer.Dispose();
                email.Attachments.ToList().ForEach(x => x.Dispose());
                return emailHTML;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        private static string GetEmailTemplate()
        {
            try
            {
                var path = Environment.GetEnvironmentVariable("EmailTemplate_Path");
                if (path == null)
                {
                    Environment.SetEnvironmentVariable("EmailTemplate_Path", "C:\\EmailTemplate\\EmailTemplate.html");
                    path = Environment.GetEnvironmentVariable("EmailTemplate_Path");
                    if (!Directory.Exists(path))
                    {
                        path = "C:\\EmailTemplate";
                        Directory.CreateDirectory(path);
                    }
                }
                else
                {
                    StreamReader stream = new(path);
                    string mailTemp = stream.ReadToEnd();
                    return mailTemp;
                }
                return path;
            }
            catch (Exception e)
            {
                LoggerService.Logger(e.ToString());
                throw new Exception(e.Message);
            }

        }
    }
}
*/