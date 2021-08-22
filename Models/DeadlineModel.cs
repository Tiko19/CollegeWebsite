using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class DeadlineModel
    {
        public int ID { get; set; }

        [Required]
        public string Intake { get; set; }

        [Required]
        [DisplayName("Starting Date")]
        public string StartDate { get; set; }

        [Required]
        [DisplayName("Closing Date")]
        public string CloseDate { get; set; }

        [Required]
        [DisplayName("Registration Period")]
        public string RegistrationDates { get; set; }
    }
}