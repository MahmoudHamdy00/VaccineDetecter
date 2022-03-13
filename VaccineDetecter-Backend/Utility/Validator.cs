namespace VaccineDetecter_Backend.Utility
{
    public class Validator
    {
        public static bool IsValidEmail(string email) {
            try {
                if (email.EndsWith(".")) {
                    return false;
                }
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
    }
}
