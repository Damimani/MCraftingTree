namespace MCraftingTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyAdded : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CraftingTables", name: "OutputSlot_ID", newName: "OutputSlotID");
            RenameIndex(table: "dbo.CraftingTables", name: "IX_OutputSlot_ID", newName: "IX_OutputSlotID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CraftingTables", name: "IX_OutputSlotID", newName: "IX_OutputSlot_ID");
            RenameColumn(table: "dbo.CraftingTables", name: "OutputSlotID", newName: "OutputSlot_ID");
        }
    }
}
