namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTotalAvailabletoRoomTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "ToalAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Rooms SET ToalAvailable=TotalRoom");
            DropColumn("dbo.Rooms", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Rooms", "ToalAvailable");
        }
    }
}
