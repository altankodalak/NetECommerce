using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace NetECommerce.Common
{
    public static class MailSender
    {
        public static void SendEmail(string email, string subject, string message)
        {

            //outlook hesap
            /*
                yzl3162@outlook.com
                Kadikoy--
             */



            //MailMessage
            MailMessage sender=new MailMessage();
            sender.From=new MailAddress("yzl3162@outlook.com","Yzl3162");
            sender.Subject=subject;
            sender.Body=message;
            sender.To.Add(email);



            //SmtpClient
            SmtpClient smtpClient=new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("yzl3162@outlook.com", "Kadikoy--");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.EnableSsl= true;

            //mail gönderimi
            smtpClient.Send(sender);


        }
    }
}
