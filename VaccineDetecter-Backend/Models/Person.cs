﻿using System.ComponentModel.DataAnnotations;

namespace VaccineDetecter_Backend.Models
{
    public class Person
    {
        [Key]
        public string NationalId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<MedicalTest> Tests { get; set; }


    }
}
