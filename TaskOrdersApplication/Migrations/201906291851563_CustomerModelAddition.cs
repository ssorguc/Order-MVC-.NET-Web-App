namespace TaskOrdersApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CustomerModelAddition : DbMigration
    {
        public override void Up()
        {
            
            Sql("DROP TABLE OrderItems;");
            Sql("DROP TABLE Orders");


        }
    }
}
