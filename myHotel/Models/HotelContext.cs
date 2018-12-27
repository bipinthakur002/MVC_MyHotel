using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace myHotel.Models
{
    public class HotelContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Booking> bookings { get; set; }
    }
}