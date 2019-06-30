namespace TaskOrdersApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelAddition1 : DbMigration
    {
        public override void Up()
        {

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    DateOfOrder = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrderItems",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 255),
                    Unit = c.Int(nullable: false),
                    Amount = c.Double(nullable: false),
                    OrderOfTheItem_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderOfTheItem_Id, cascadeDelete: true)
                .Index(t => t.OrderOfTheItem_Id);

            CreateTable(
                   "dbo.Customers",
                   c => new
                   {
                       Id = c.Int(nullable: false, identity: true),
                       UserName = c.String(nullable: false),
                       Password = c.String(nullable: false),
                   })
                   .PrimaryKey(t => t.Id);

            AddColumn("dbo.Orders", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "CustomerId");



        }

        
    }
}
