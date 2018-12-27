using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myHotel.Models
{
    public class Room
    {

        public int Id { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int TotalRoom { get; set; }
       public int ToalAvailable { get; set; }                                  
         // public bool Status { get; set; }
        [Required]
      //  [Remote("IsRoomTypeAvailable", "Room", ErrorMessage = "Already Created Room For this Type Edit If any Changes.")]
        public RoomType Roomtype { get; set; }

    }
  
   
    public enum RoomType
    {
        Single,
        Double,
        Triple,
        Quad,
        Queen,
        King

    }

}