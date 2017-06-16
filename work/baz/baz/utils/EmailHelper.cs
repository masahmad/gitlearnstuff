using System;
using System.Collections.Generic;

using System.Web;
using System.Text;

using System.Net.Mail;
using System.Configuration;



namespace Email.Utils
{
    public class EmailHelper
    {






        public static string SendEmail(string toAddr,string action, string extradetail)
        {


            string fromAddr = ConfigurationManager.AppSettings["fromAddr"];
            string emailHost = ConfigurationManager.AppSettings["emailserver"];
            string emailSubject = ConfigurationManager.AppSettings["emailSubject"];

            string smtpUid = ConfigurationManager.AppSettings["smtpUid"];
            string smtpPass = ConfigurationManager.AppSettings["smtpPass"];
            string rtnMessage = "";


            string guid = extradetail;
            string emailConfirmURL =  ConfigurationManager.AppSettings["emailConfirmURL"];
            emailConfirmURL = emailConfirmURL.Replace("guid", guid);
            
            emailConfirmURL = emailConfirmURL.Replace("_email", "&email");
            emailConfirmURL = emailConfirmURL.Replace("emailaddress", toAddr);




            StringBuilder emailBody = new StringBuilder();

           // emailBody.AppendLine("<html><head><link href='http://insiteeudev01/apps/eventbooking/Styles/Site.css' rel='stylesheet' type='text/css' /><title>VISA Event booking 02</title></head><body>");

            emailBody.AppendLine("<html><head><title>Bazaar TV</title></head><body>");

           

            switch (action)
            {
                case "return":
                   
                        emailBody.AppendLine("<br><br/>Your request has been returned - please select event again and update as appropriate.<br><br>");
                        break;
                   

                case "reject":
                   
                        emailBody.AppendLine("<br><br/>Your request for the 02 event has been rejected.<br><br>");
                        break;
                   

                case "approve":
                   
                        emailBody.AppendLine("<br><br/>Your 02 Event request has been approved.<br><br>");
                        break;
                   


                case "register":
                   
                        emailBody.AppendLine("<br><br/>Thanks for registering. Please click the link below to confirm your email address<br><br>");

                        emailBody.AppendLine(emailConfirmURL);
                        emailBody.AppendLine("<br><br>");
                        emailBody.AppendLine("bazaar tv");
                       
                        break;

                default:
                        emailBody.AppendLine("abc");
                        break;


            }
            
            
            string fromEm = fromAddr;
            string toEm = toAddr;

              
            emailBody.AppendLine("<br></body></html>");
                     
            MailAddress from = new MailAddress(fromEm);
            MailAddress to = new MailAddress(toEm);
            MailMessage msg = new MailMessage(from, to);

            msg.Subject = emailSubject;
            msg.Body = emailBody.ToString();
            msg.IsBodyHtml = true;
            
            SmtpClient smtp = new SmtpClient(emailHost);

            smtp.Credentials = new System.Net.NetworkCredential(smtpUid,smtpPass);
            //smtp.UseDefaultCredentials = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //smtp.EnableSsl = true;
            smtp.Port = 25;
             

            try
            {
                smtp.Send(msg);
            }

            catch (SmtpException sme)
            {
                rtnMessage = "Approval Email failure: " + sme.Message;
                throw new Exception(rtnMessage);
            }


            return rtnMessage;
        }

       

    }

}
