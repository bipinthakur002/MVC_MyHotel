namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumnBookingdatetoBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "BookingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "BookingDate");
        }
    }
}
