namespace TaskOrdersApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequierdCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "UserName", c => c.String());
        }
    }
}
