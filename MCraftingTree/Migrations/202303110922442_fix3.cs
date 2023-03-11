namespace MCraftingTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CraftingTables", "OutputAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CraftingTables", "OutputAmount");
        }
    }
}
