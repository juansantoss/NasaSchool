using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NasaSchool.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full Name can't be null")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "SSN can't be null")]
        public string Ssn { get; set; }
        [Required(ErrorMessage = "Year can't be null")]
        public int Year { get; set; }
    }
}
