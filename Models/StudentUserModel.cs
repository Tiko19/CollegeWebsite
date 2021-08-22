using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class StudentUserModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Student ID")]
        public string StudentID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}