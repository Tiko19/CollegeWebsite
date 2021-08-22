using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class NoticeModel
    {
        public int ID { get; set; }

        [Required]
        public string Notice { get; set; }

        [Required]
        [DisplayName("Date")][DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }
    }
}