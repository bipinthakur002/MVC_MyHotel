namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTotalRoomtoRoomTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "TotalRoom", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "TotalRoom");
        }
    }
}
