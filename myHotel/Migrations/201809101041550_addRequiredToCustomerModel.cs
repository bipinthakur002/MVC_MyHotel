namespace myHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Adhar", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Adhar", c => c.String());
            AlterColumn("dbo.Customers", "Mobile", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
