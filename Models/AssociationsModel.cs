using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class AssociationsModel
    {
        public int ID { get; set; }

        [Required]
        public string Association { get; set; }

        [Required]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}