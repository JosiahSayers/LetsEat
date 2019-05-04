using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetsEat.DAL;
using LetsEat.DAL.SQL;
using LetsEat.Models;
using LetsEat.Models.Email;
using LetsEat.Models.Forms;
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

        public bool FamilyRoleChanged(FamilyRoleEmail model)
        {
            bool output = false;

            try
            {
                to = new MailboxAddress(model.User.DisplayName, model.User.Email);
                message.To.Add(to);

                message.Subject = $"{model.UserWhoMadeChange.DisplayName} has changed your role in the {model.Family.Name} family.";

                body.HtmlBody = $"<h1>Hi {model.User.DisplayName}!</h1><p>We just wanted to let you know that {model.UserWhoMadeChange.DisplayName} has changed your role in the {model.Family.Name} Family.</p><strong>Previous Role: </strong>{model.PreviousRole}<p><strong>New Role: </strong>{model.User.FamilyRole}</p><p></p><br><p>- The Let's Eat Team</p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool DeclineInvite(InviteResponse ir)
        {
            bool output = false;

            try
            {
                to = new MailboxAddress(ir.Inviter.DisplayName, ir.Inviter.Email);
                message.To.Add(to);

                message.Subject = $"{ir.Invitee.DisplayName} has chosen not to join the {ir.Family.Name} family.";

                body.HtmlBody = $"<h1>Hi {ir.Inviter.DisplayName}!</h1><p>We just wanted to let you know that {ir.Invitee.DisplayName} has declined your request to join the {ir.Family.Name} family.</p><br><p>- The Let's Eat Team</p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool AcceptInvite(InviteResponse ir)
        {
            bool output = false;

            try
            {
                to = new MailboxAddress(ir.Inviter.DisplayName, ir.Inviter.Email);
                message.To.Add(to);

                message.Subject = $"{ir.Invitee.DisplayName} has joined the {ir.Family.Name} family.";

                body.HtmlBody = $"<h1>Hi {ir.Inviter.DisplayName}!</h1><p>We just wanted to let you know that {ir.Invitee.DisplayName} has accepted your request to join the {ir.Family.Name} family!<br><p>- The Let's Eat Team</p></p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool Invite(User invitee, User familyLeader, Family family)
        {
            bool output = false;

            try
            {
                to = new MailboxAddress(invitee.DisplayName, invitee.Email);
                message.To.Add(to);

                message.Subject = $"{familyLeader.DisplayName} has invited you to join the {family.Name} family.";

                body.HtmlBody = $"<h1>Hi {invitee.DisplayName}!</h1><p>{familyLeader.DisplayName} sent you an invite to join the {family.Name} family. Log in to your account now and click on <strong>'Welcome {invitee.DisplayName}'</strong> at the top right to respond to this invite.</p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool Welcome(User user)
        {
            bool output = false;

            try
            {
                to = new MailboxAddress(user.DisplayName, user.Email);
                message.To.Add(to);

                message.Subject = $"Welcome to Let's Eat!";

                body.HtmlBody = $"<h1>Hi {user.DisplayName}!</h1><p>We're so glad to have you as a new user on Let's Eat. To get the most out of your account, make sure to either join an existing family or create your family and invite your family members!</p><p>- Let's Eat Admin Team</p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool WebsiteRequestDenied(DenyWebsiteRequest model)
        {
            bool output = false;

            try
            {
                to = new MailboxAddress(model.WebsiteRequest.User.DisplayName, model.WebsiteRequest.User.Email);
                message.To.Add(to);

                message.Subject = $"Your request to add {model.WebsiteRequest.BaseURL} has been denied by an admin";

                body.HtmlBody = $"<h1>Hi {model.WebsiteRequest.User.DisplayName}</h1><p>Your request to add {model.WebsiteRequest.BaseURL} has been denied by an admin, here's why: </p><br><p>{model.Message}</p><br><p>Sorry that we were not able to complete this for you :'(</p><p>- Let's Eat Admin Team</p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }
            catch
            {
                output = false;
            }

            return output;
        }

        public bool WebsiteRequestComplete(WebsiteRequest wr)
        {
            bool output = false;

            try
            {
                to = new MailboxAddress(wr.User.DisplayName, wr.User.Email);
                message.To.Add(to);

                message.Subject = $"Your request to add {wr.BaseURL} to our recipe import is complete!";

                body.HtmlBody = $"<h1>Hi {wr.User.DisplayName}</h1><p>Thank you for your patience while we added the capability to import recipes from {wr.BaseURL}. I am glad to inform you that this website has now been added to Let's Eat! You can now try and import this recipe again, as a reminder the recipe you were trying to add was <a href='{wr.FullURL}'>located here.</a></p> <p>Thanks again for your patience!</p><p>- Let's Eat Admin Team</p>";
                message.Body = body.ToMessageBody();

                output = Connect() && Send() ? true : false;
            }
            catch
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
