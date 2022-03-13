namespace VaccineDetecter_Backend.Models
{
    public class MedicalTest
    {
        public int Id { get; set; }
        public int WhiteBloodCell { get; set; }
        public int RedBloodCell { get; set; }
        public string TestDate { get; set; }
        public string PersonId { get; set; }
        public Person person { get; set; }
    }
}
