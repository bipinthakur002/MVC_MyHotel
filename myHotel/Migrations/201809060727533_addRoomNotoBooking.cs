namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRoomNotoBooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "RoomNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "RoomNo");
        }
    }
}
