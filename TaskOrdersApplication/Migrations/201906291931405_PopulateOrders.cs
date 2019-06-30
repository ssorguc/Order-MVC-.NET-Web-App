namespace TaskOrdersApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrders : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ORDERS (DATEOFORDER,CUSTOMER_ID) VALUES ( '2019-02-02', 5)");


            Sql("INSERT INTO ORDERITEMS ( NAME,UNIT, AMOUNT,ORDEROFTHEITEM) VALUES ('Phone', 1,299.99, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
