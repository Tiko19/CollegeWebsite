using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class UserModel
    {
        public int ID { get; set; }

        [Required][DisplayName("User ID")]
        public string UserID { get; set; }

        [Required]
        public string Password { get; set; }
    }
}