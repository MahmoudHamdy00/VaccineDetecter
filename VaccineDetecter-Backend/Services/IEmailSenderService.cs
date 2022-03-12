namespace VaccineDetecter_Backend.Services
{
    public interface IEmailSenderService
    {
        void SendEmail(string emailTo, string MailSubject, string MailBody, bool isHTML = true);
    }
}