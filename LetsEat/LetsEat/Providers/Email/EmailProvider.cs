using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace LetsEat.Providers.Email
{
    public class EmailProvider
    {
        private MailboxAddress from = new MailboxAddress("Let's Eat", "letseatmailer@gmail.com");
        private MailboxAddress to;
        private SmtpClient client = new SmtpClient();
        private MimeMessage message = new MimeMessage();
        private BodyBuilder body = new BodyBuilder();
        private string EmailProviderPassword;

        public EmailProvider(string pass)
        {
            message.From.Add(from);
            EmailProviderPassword = pass;
        }

        public bool Test()
        {
            bool output;

            to = new MailboxAddress("Josiah", "josiah.sayers15@gmail.com");
            message.To.Add(to);
            message.Subject = "This is a test email subject.";

            body.TextBody = "This is a test email body.";
            message.Body = body.ToMessageBody();

            if(Connect() && Send())
            {
                output = true;
            }
            else
            {
                output = false;
            }
            return output;
        }

        private bool Connect()
        {
            bool output;
            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate("letseatmailer@gmail.com", EmailProviderPassword);

                output = true;
            }
            catch
            {
                output = false;
            }
            return output;
        }

        private bool Send()
        {
            bool output;
            try
            {
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();

                output = true;
            }
            catch
            {
                output = false;
            }
            return output;
        }
    }
}
