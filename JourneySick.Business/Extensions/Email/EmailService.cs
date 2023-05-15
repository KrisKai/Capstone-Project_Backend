using System;
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
        private static readonly string APP_PASSWORD = "cxrdzurzsizgzaep";
        private static readonly string SENDER = "journeysick.noreply@gmail.com";
        public static async Task SendEmail(string fullname, /*string filePath,*/ string receiver, string tripId)
        {
            string SendMailSubject = "JourneySick - Invitation To Another Journey!!!";
            string link = "";
            string SendMailBody = "Bạn được mời tham gia chuyển đi của "+ fullname+ "\nNhấn  < a href = '"+link+"' > vào đây </ a > ' để chấp nhận tham gia";

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
                    Body = SendMailBody
                };

                email.To.Add(receiver);
                email.CC.Add(SENDER);

                //END

                SmtpServer.Send(email);
                email.Attachments.ToList().ForEach(x => x.Dispose());
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
