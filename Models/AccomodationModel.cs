using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeWebsite.Models
{
    public class AccomodationModel
    {
        public int ID { get; set; }

        [Required]
        [DisplayName("Room Type")]
        public string RoomType { get; set; }

        [Required]
        public string Bathroom { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}