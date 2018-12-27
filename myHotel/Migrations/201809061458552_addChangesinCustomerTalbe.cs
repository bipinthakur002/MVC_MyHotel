namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChangesinCustomerTalbe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Mobile", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
