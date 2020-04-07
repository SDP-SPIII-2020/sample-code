using System.Net.Mail;

namespace SRP
{
    public class UserManagement
    {
        public void Register(string email, string password)
        {
            //
            ValidateEmail(email);
            SendEmail(new MailMessage("@", email));
        }

        // ----------------------------------- Should be a separate EmailService class
        public bool ValidateEmail(string email)
        {
            return email.Contains("@");
        }
        public bool SendEmail(MailMessage msg)
        {
            return true;
        }
    }
}