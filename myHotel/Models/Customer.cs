using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myHotel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public string Mobile { get; set; }
        
        [Required]
        public string Adhar { get; set; }


        [Required]
        [EmailAddress]
        [Remote("IsEmailAvailable", "Customer",  ErrorMessage = "EmailId already exists in database.")]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

    }


   



}