using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class ResultModel
    {
        public int Id { get; set; }

        [Required][DisplayName ("Student ID")]
        public string StudentID { get; set; }

        [Required][DisplayName ("Course Name")]
        public string CourseName { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required][DisplayName ("Grade Point")]
        [DisplayFormat(DataFormatString = "{0:0.0}")]
        public decimal GradePoint { get; set; }
    }
}