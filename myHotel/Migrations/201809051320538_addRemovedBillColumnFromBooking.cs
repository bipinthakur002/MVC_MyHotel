namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRemovedBillColumnFromBooking : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "Bill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Bill", c => c.Int(nullable: false));
        }
    }
}
