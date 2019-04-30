using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.DAL.SQL;
using LetsEat.Models;
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

        IUsersDAL userDAL;

        public EmailProvider(string pass, string connectionString)
        {
            message.From.Add(from);
            EmailProviderPassword = pass;
            this.userDAL = new UserSqlDAL(connectionString);
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

        public bool NewWebsiteRequest(WebsiteRequest wr)
        {
            bool output = false;

            foreach (User admin in GetAdmins())
            {
                to = new MailboxAddress(admin.DisplayName, admin.Email);
                message.To.Add(to);

                message.Subject = $"{wr.User.DisplayName} is requesting a new website to be added to Let's Eat Import.";

                body.HtmlBody = $"<h1>Hi {admin.DisplayName}</h1><p>The user {wr.User.DisplayName} just tried to import a recipe from {wr.BaseURL}. You should add this website asap and mark it as completed.</p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }

            return output;
        }

        private List<User> GetAdmins()
        {
            return userDAL.GetAdmins();
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
