﻿using System;
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
        public static async Task SendEmailTrip(string fullname, /*string filePath,*/ string receiver, string receiverName, int memberId)
        {
            string SendMailSubject = "JourneySick - Invitation To Another Journey!!!";
            string link = "http://localhost:3000/confirmPage/" + memberId;
            string SendMailBody = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" style=\"width:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0\"><head><meta charset=\"UTF-8\"><meta content=\"width=device-width, initial-scale=1\" name=\"viewport\"><meta name=\"x-apple-disable-message-reformatting\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta content=\"telephone=no\" name=\"format-detection\"><title>New message</title><!--[if (mso 16)]><style type=\"text/css\"> a {text-decoration: none;} </style><![endif]--><!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--><!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml><![endif]--><style type=\"text/css\">#outlook a { padding:0;}.ExternalClass { width:100%;}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div { line-height:100%;}.es-button { mso-style-priority:100!important; text-decoration:none!important;}a[x-apple-data-detectors] { color:inherit!important; text-decoration:none!important; font-size:inherit!important; font-family:inherit!important; font-weight:inherit!important; line-height:inherit!important;}.es-desk-hidden { display:none; float:left; overflow:hidden; width:0; max-height:0; line-height:0; mso-hide:all;}[data-ogsb] .es-button { border-width:0!important; padding:10px 20px 10px 20px!important;}@media only screen and (max-width:600px) {p, ul li, ol li, a { line-height:150%!important } h1, h2, h3, h1 a, h2 a, h3 a { line-height:120%!important } h1 { font-size:30px!important; text-align:center } h2 { font-size:26px!important; text-align:center } h3 { font-size:20px!important; text-align:center } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:30px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:26px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-menu td a { font-size:16px!important } .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:16px!important } .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:16px!important } .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:16px!important } .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:12px!important } *[class=\"gmail-fix\"] { display:none!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-button-border { display:block!important } a.es-button, button.es-button { font-size:20px!important; display:block!important; border-width:10px 0px 10px 0px!important } .es-btn-fw { border-width:10px 0px!important; text-align:center!important } .es-adaptive table, .es-btn-fw, .es-btn-fw-brdr, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .es-adapt-td { display:block!important; width:100%!important } .adapt-img { width:100%!important; height:auto!important } .es-m-p0 { padding:0px!important } .es-m-p0r { padding-right:0px!important } .es-m-p0l { padding-left:0px!important } .es-m-p0t { padding-top:0px!important } .es-m-p0b { padding-bottom:0!important } .es-m-p20b { padding-bottom:20px!important } .es-mobile-hidden, .es-hidden { display:none!important } tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } table.es-social { display:inline-block!important } table.es-social td { display:inline-block!important } .es-desk-hidden { display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important } .h-auto { height:auto!important } }</style></head>\r\n<body style=\"width:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;font-family:verdana, geneva, sans-serif;padding:0;Margin:0\"><div class=\"es-wrapper-color\" style=\"background-color:#F6F6F6\"><!--[if gte mso 9]><v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\"> <v:fill type=\"tile\" src=\"https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/7711511856111535.png\" color=\"#f6f6f6\" origin=\"0.5, 0\" position=\"0.5, 0\"></v:fill> </v:background><![endif]--><table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" background=\"https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/7711511856111535.png\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-image:url(https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/7711511856111535.png);background-repeat:repeat;background-position:center top;background-color:#F6F6F6\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-header\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\"><tr style=\"border-collapse:collapse\"><td class=\"es-adaptive\" align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-header-body\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"padding:0;Margin:0\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;font-size:0px\"><img class=\"adapt-img\" src=\"https://zrzloq.stripocdn.email/content/guids/CABINET_2005528da0400ed36d47e3f6434e16f1/images/screenshot_20221205_231540removebgpreview.png\" alt style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"310\" height=\"104\"></td>\r\n</tr></table></td></tr></table></td></tr></table></td>\r\n</tr></table><table class=\"es-content\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#ffffff;width:600px\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\" align=\"center\"><tr style=\"border-collapse:collapse\"><td style=\"padding:0;Margin:0;background-color:#f3f3f3\" bgcolor=\"#f3f3f3\" align=\"left\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"Margin:0;padding-bottom:15px;padding-left:15px;padding-right:15px;padding-top:30px\">\r\n</td></tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-bottom:15px;font-size:0\"><img class=\"adapt-img\" src=\"https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/63541516368770627.png\" alt=\"Handshake\" title=\"Handshake\" width=\"600\" height=\"258\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td></tr></table></td></tr></table></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"Margin:0;padding-bottom:10px;padding-top:20px;padding-left:30px;padding-right:30px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:540px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"padding:0;Margin:0;padding-top:15px\"><h3 style=\"Margin:0;line-height:24px;mso-line-height-rule:exactly;font-family:georgia, times, 'times new roman', serif;font-size:20px;font-style:normal;font-weight:normal;color:#24578E\">Gửi "+receiverName+",</h3></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td class=\"es-m-txt-c\" align=\"left\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#333333;font-size:14px\">Bạn được mời tham gia chuyển đi của "+fullname+"</p></td></tr><tr style=\"border-collapse:collapse\">\r\n</tr><tr style=\"border-collapse:collapse\"><td class=\"es-m-txt-c\" align=\"left\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#333333;font-size:14px\">Nhấn vào link để chấp nhận tham gia: " + link + "</p></td></tr><tr style=\"border-collapse:collapse\">\r\n</tr></table><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-footer\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-footer-body\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#333333;width:600px\"><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"Margin:0;padding-top:20px;padding-bottom:20px;padding-left:20px;padding-right:20px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-bottom:10px;font-size:0\"><table class=\"es-table-not-adapt es-social\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Facebook\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/facebook-logo-gray.png\" alt=\"Fb\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td>\r\n<td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Twitter\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/twitter-logo-gray.png\" alt=\"Tw\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Instagram\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/instagram-logo-gray.png\" alt=\"Inst\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td>\r\n<td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Youtube\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/youtube-logo-gray.png\" alt=\"Yt\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td></tr></table></td></tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-top:5px;padding-bottom:5px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\">+84 913576923</p>\r\n<p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\"><a target=\"_blank\" href=\"mailto:your@mail.com\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;color:#FFFFFF;font-size:14px\">Krowd.2022.dev@gmail.com</a></p><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\">LawServices, Inc. 62 Long St. Salt Lake City, UT 12345</p></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-top:5px;padding-bottom:5px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:12px\">Make sure our messages get to your Inbox (and not your bulk or junk folders). Please add&nbsp;<a target=\"_blank\" href=\"mailto:your@mail.com\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#FFFFFF;font-size:14px\">journeysick.noreply@gmail.com</a>&nbsp;to your contacts!</p></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\"><span style=\"font-size:12px;line-height:18px\">LawServices © All Rights Reserved</span><br></p></td></tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:24px;color:#FFFFFF;font-size:16px\">Vector graphics designed by <strong><a target=\"_blank\" href=\"http://www.freepik.com/\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#FFFFFF;font-size:14px\">Freepik</a></strong>.</p></td>\r\n</tr></table></td></tr></table></td></tr></table></td></tr></table></td></tr></table></div></body></html>";
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

                string emailHTML = GetEmailTemplate();
                email.Body = SendMailBody;

                email.To.Add(receiver);
                email.CC.Add(SENDER);

                email.IsBodyHtml = true;

                SmtpServer.Send(email);

                SmtpServer.Dispose();
                email.Attachments.ToList().ForEach(x => x.Dispose());
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public static async Task SendEmailRegister(string receiver, string receiverName, string userId)
        {
            string SendMailSubject = "JourneySick - Welcome To JourneySick!!!";
            string link = "http://localhost:3000/confirmPageUser/" + userId;
            string SendMailBody = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" style=\"width:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0\"><head><meta charset=\"UTF-8\"><meta content=\"width=device-width, initial-scale=1\" name=\"viewport\"><meta name=\"x-apple-disable-message-reformatting\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta content=\"telephone=no\" name=\"format-detection\"><title>New message</title><!--[if (mso 16)]><style type=\"text/css\"> a {text-decoration: none;} </style><![endif]--><!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--><!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml><![endif]--><style type=\"text/css\">#outlook a { padding:0;}.ExternalClass { width:100%;}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div { line-height:100%;}.es-button { mso-style-priority:100!important; text-decoration:none!important;}a[x-apple-data-detectors] { color:inherit!important; text-decoration:none!important; font-size:inherit!important; font-family:inherit!important; font-weight:inherit!important; line-height:inherit!important;}.es-desk-hidden { display:none; float:left; overflow:hidden; width:0; max-height:0; line-height:0; mso-hide:all;}[data-ogsb] .es-button { border-width:0!important; padding:10px 20px 10px 20px!important;}@media only screen and (max-width:600px) {p, ul li, ol li, a { line-height:150%!important } h1, h2, h3, h1 a, h2 a, h3 a { line-height:120%!important } h1 { font-size:30px!important; text-align:center } h2 { font-size:26px!important; text-align:center } h3 { font-size:20px!important; text-align:center } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:30px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:26px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-menu td a { font-size:16px!important } .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:16px!important } .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:16px!important } .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:16px!important } .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:12px!important } *[class=\"gmail-fix\"] { display:none!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-button-border { display:block!important } a.es-button, button.es-button { font-size:20px!important; display:block!important; border-width:10px 0px 10px 0px!important } .es-btn-fw { border-width:10px 0px!important; text-align:center!important } .es-adaptive table, .es-btn-fw, .es-btn-fw-brdr, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .es-adapt-td { display:block!important; width:100%!important } .adapt-img { width:100%!important; height:auto!important } .es-m-p0 { padding:0px!important } .es-m-p0r { padding-right:0px!important } .es-m-p0l { padding-left:0px!important } .es-m-p0t { padding-top:0px!important } .es-m-p0b { padding-bottom:0!important } .es-m-p20b { padding-bottom:20px!important } .es-mobile-hidden, .es-hidden { display:none!important } tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } table.es-social { display:inline-block!important } table.es-social td { display:inline-block!important } .es-desk-hidden { display:table-row!important; width:auto!important; overflow:visible!important; max-height:inherit!important } .h-auto { height:auto!important } }</style></head>\r\n<body style=\"width:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;font-family:verdana, geneva, sans-serif;padding:0;Margin:0\"><div class=\"es-wrapper-color\" style=\"background-color:#F6F6F6\"><!--[if gte mso 9]><v:background xmlns:v=\"urn:schemas-microsoft-com:vml\" fill=\"t\"> <v:fill type=\"tile\" src=\"https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/7711511856111535.png\" color=\"#f6f6f6\" origin=\"0.5, 0\" position=\"0.5, 0\"></v:fill> </v:background><![endif]--><table class=\"es-wrapper\" width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" background=\"https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/7711511856111535.png\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-image:url(https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/7711511856111535.png);background-repeat:repeat;background-position:center top;background-color:#F6F6F6\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" style=\"padding:0;Margin:0\"><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-header\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\"><tr style=\"border-collapse:collapse\"><td class=\"es-adaptive\" align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-header-body\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px\"><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"padding:0;Margin:0\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;font-size:0px\"><img class=\"adapt-img\" src=\"https://zrzloq.stripocdn.email/content/guids/CABINET_2005528da0400ed36d47e3f6434e16f1/images/screenshot_20221205_231540removebgpreview.png\" alt style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\" width=\"310\" height=\"104\"></td>\r\n</tr></table></td></tr></table></td></tr></table></td>\r\n</tr></table><table class=\"es-content\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-content-body\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#ffffff;width:600px\" cellspacing=\"0\" cellpadding=\"0\" bgcolor=\"#ffffff\" align=\"center\"><tr style=\"border-collapse:collapse\"><td style=\"padding:0;Margin:0;background-color:#f3f3f3\" bgcolor=\"#f3f3f3\" align=\"left\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:600px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"Margin:0;padding-bottom:15px;padding-left:15px;padding-right:15px;padding-top:30px\">\r\n</td></tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-bottom:15px;font-size:0\"><img class=\"adapt-img\" src=\"https://zrzloq.stripocdn.email/content/guids/CABINET_63fbbc11db6741389cc3292b09a63e6d/images/63541516368770627.png\" alt=\"Handshake\" title=\"Handshake\" width=\"600\" height=\"258\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td></tr></table></td></tr></table></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"Margin:0;padding-bottom:10px;padding-top:20px;padding-left:30px;padding-right:30px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:540px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"padding:0;Margin:0;padding-top:15px\"><h3 style=\"Margin:0;line-height:24px;mso-line-height-rule:exactly;font-family:georgia, times, 'times new roman', serif;font-size:20px;font-style:normal;font-weight:normal;color:#24578E\">Gửi " + receiverName + ",</h3></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td class=\"es-m-txt-c\" align=\"left\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#333333;font-size:14px\">Bạn vừa mới tạo tài khoản với email này.</p></td></tr><tr style=\"border-collapse:collapse\">\r\n</tr><tr style=\"border-collapse:collapse\"><td class=\"es-m-txt-c\" align=\"left\" style=\"padding:0;Margin:0;padding-top:10px;padding-bottom:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#333333;font-size:14px\">Nhấn vào link để xác thực: " + link + "</p></td></tr><tr style=\"border-collapse:collapse\">\r\n</tr></table><table cellpadding=\"0\" cellspacing=\"0\" class=\"es-footer\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0\"><table class=\"es-footer-body\" cellspacing=\"0\" cellpadding=\"0\" align=\"center\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#333333;width:600px\"><tr style=\"border-collapse:collapse\"><td align=\"left\" style=\"Margin:0;padding-top:20px;padding-bottom:20px;padding-left:20px;padding-right:20px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;width:560px\"><table width=\"100%\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-bottom:10px;font-size:0\"><table class=\"es-table-not-adapt es-social\" cellspacing=\"0\" cellpadding=\"0\" role=\"presentation\" style=\"mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px\"><tr style=\"border-collapse:collapse\"><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Facebook\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/facebook-logo-gray.png\" alt=\"Fb\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td>\r\n<td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Twitter\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/twitter-logo-gray.png\" alt=\"Tw\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td><td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Instagram\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/instagram-logo-gray.png\" alt=\"Inst\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td>\r\n<td valign=\"top\" align=\"center\" style=\"padding:0;Margin:0;padding-right:10px\"><img title=\"Youtube\" src=\"https://zrzloq.stripocdn.email/content/assets/img/social-icons/logo-gray/youtube-logo-gray.png\" alt=\"Yt\" width=\"32\" height=\"32\" style=\"display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic\"></td></tr></table></td></tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-top:5px;padding-bottom:5px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\">+84 913576923</p>\r\n<p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\"><a target=\"_blank\" href=\"mailto:your@mail.com\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:none;color:#FFFFFF;font-size:14px\">Krowd.2022.dev@gmail.com</a></p><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\">LawServices, Inc. 62 Long St. Salt Lake City, UT 12345</p></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-top:5px;padding-bottom:5px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:12px\">Make sure our messages get to your Inbox (and not your bulk or junk folders). Please add&nbsp;<a target=\"_blank\" href=\"mailto:your@mail.com\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#FFFFFF;font-size:14px\">journeysick.noreply@gmail.com</a>&nbsp;to your contacts!</p></td>\r\n</tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:21px;color:#FFFFFF;font-size:14px\"><span style=\"font-size:12px;line-height:18px\">LawServices © All Rights Reserved</span><br></p></td></tr><tr style=\"border-collapse:collapse\"><td align=\"center\" style=\"padding:0;Margin:0;padding-top:10px\"><p style=\"Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:verdana, geneva, sans-serif;line-height:24px;color:#FFFFFF;font-size:16px\">Vector graphics designed by <strong><a target=\"_blank\" href=\"http://www.freepik.com/\" style=\"-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;text-decoration:underline;color:#FFFFFF;font-size:14px\">Freepik</a></strong>.</p></td>\r\n</tr></table></td></tr></table></td></tr></table></td></tr></table></td></tr></table></div></body></html>";
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
                email.Body = SendMailBody;

                email.To.Add(receiver);
                email.CC.Add(SENDER);

                email.IsBodyHtml = true;

                SmtpServer.Send(email);

                SmtpServer.Dispose();
                email.Attachments.ToList().ForEach(x => x.Dispose());
               // return emailHTML;
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
                throw new Exception(e.Message);
            }

        }
    }
}
