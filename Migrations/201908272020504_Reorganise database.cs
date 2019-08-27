namespace InventoryNatific.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reorganisedatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Inventories", newName: "Inventory");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Inventory", newName: "Inventories");
        }
    }
}
