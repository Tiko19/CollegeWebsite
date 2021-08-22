using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class ProgramsModel
    {
        public int ID { get; set; }

        [Required]
        public string Program { get; set; }

        [Required]
        public string Intake { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Tuition { get; set; }
    }
}