namespace TaskOrdersApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContextEdit : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderOfTheItem_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.OrderItems", new[] { "OrderOfTheItem_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropTable("dbo.OrderItems");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
