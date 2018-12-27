using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myHotel.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public int RoomId { get; set; }
        public Room room { get; set; }
        [RestrictedDate(ErrorMessage = "Date must be after or equal to current date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.Date)]
        [RestrictedDate(ErrorMessage = "Date must be after or equal to current date")]
        [Required]
        public DateTime CheckOut { get; set; }
        public DateTime BookingDate { get; set; }
        public int RoomNo { get; set; }
        //public int Bill { get; set; }
    }
    public class RestrictedDate : ValidationAttribute
    {
        public override bool IsValid(object date)
        {
            DateTime datee = (DateTime)date;
            if (datee >= DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}