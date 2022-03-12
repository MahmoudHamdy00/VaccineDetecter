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
    }
}
