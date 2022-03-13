using System.Net.Mail;

namespace VaccineDetecter_Backend.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _SMTPServerAddress;
        private readonly int _mailSubmissionPort;

        public EmailSenderService(string email, string password, string SMTPServerAddress, int mailSubmissionPort) {
            _email = email;
            _password = password;
            _SMTPServerAddress = SMTPServerAddress;
            _mailSubmissionPort = mailSubmissionPort;
        }
        public void SendEmail(string emailTo, string MailSubject, string MailBody, bool isHTML = true) {
            MailBody = GetMessageBody();
            MailSubject = "Vaccine Result";
            //to be ubdated t o use ML Model to detect the vaccine type;
            MailMessage mailMessage = new MailMessage(_email, emailTo);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailBody;
            mailMessage.IsBodyHtml = isHTML;
            SmtpClient smtpClient = new SmtpClient(_SMTPServerAddress, _mailSubmissionPort);
            smtpClient.Credentials = new System.Net.NetworkCredential() {
                UserName = _email,
                Password = _password
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
            return;
        }
        public string GetMessageBody() {
            var vaccines = GetVaccine();
            var message = "Hello dear,\n";
            message += $"your test result is available and is approved by alfa scan .\nthe lab confirmed that {vaccines} is suitable for you";
            return message;
        }
        public string GetVaccine() {
            var vaccines = new List<string>() { "Moderna", "Pfizer/BioNTech", "Gamaleya", "Janssen (Johnson & Johnson)", "Strazenka" };
            var rnd = new Random();
            int idx = rnd.Next(vaccines.Count);
            return vaccines[idx];
        }

    }
}
