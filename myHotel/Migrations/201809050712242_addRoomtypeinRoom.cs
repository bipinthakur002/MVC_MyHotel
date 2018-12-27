namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRoomtypeinRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Roomtype", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "Roomtype");
        }
    }
}
