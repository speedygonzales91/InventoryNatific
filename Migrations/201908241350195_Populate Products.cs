namespace InventoryNatific.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProducts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products (Name, Price, Description, Weight) VALUES ('Windscreen',200,'Transparent Windscreen' ,5)");
            Sql("INSERT INTO Products (Name, Price, Description, Weight) VALUES ('Tyre',150,'Summer Tyre',3)");
            Sql("INSERT INTO Products (Name, Price, Description, Weight) VALUES ('Bumper',100,'Black Bumper' ,2)");
        }
        
        public override void Down()
        {
        }
    }
}
