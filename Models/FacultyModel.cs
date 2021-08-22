using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class FacultyModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public string WeChat { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}