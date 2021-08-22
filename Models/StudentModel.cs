using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class StudentModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Student ID")]
        public string StudentID { get; set; }

        [Required]
        [DisplayName ("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string Passport { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Application Type")]
        public string ApplicationType { get; set; }

        [Required]
        [DisplayName("Study Duration")]
        public string StudyDuration { get; set; }

        [Required]
        public string Major { get; set; }
    }
}