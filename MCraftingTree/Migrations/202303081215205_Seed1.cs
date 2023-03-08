namespace MCraftingTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Brewings", name: "OutputSlot_ID", newName: "OutputSlotID");
            RenameColumn(table: "dbo.Furnaces", name: "OutputSlot_ID", newName: "OutputSlotID");
            RenameColumn(table: "dbo.MobDrops", name: "Drops_ID", newName: "DropsID");
            RenameColumn(table: "dbo.Types", name: "Item_ID", newName: "ItemID");
            RenameIndex(table: "dbo.Brewings", name: "IX_OutputSlot_ID", newName: "IX_OutputSlotID");
            RenameIndex(table: "dbo.Furnaces", name: "IX_OutputSlot_ID", newName: "IX_OutputSlotID");
            RenameIndex(table: "dbo.MobDrops", name: "IX_Drops_ID", newName: "IX_DropsID");
            RenameIndex(table: "dbo.Types", name: "IX_Item_ID", newName: "IX_ItemID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Types", name: "IX_ItemID", newName: "IX_Item_ID");
            RenameIndex(table: "dbo.MobDrops", name: "IX_DropsID", newName: "IX_Drops_ID");
            RenameIndex(table: "dbo.Furnaces", name: "IX_OutputSlotID", newName: "IX_OutputSlot_ID");
            RenameIndex(table: "dbo.Brewings", name: "IX_OutputSlotID", newName: "IX_OutputSlot_ID");
            RenameColumn(table: "dbo.Types", name: "ItemID", newName: "Item_ID");
            RenameColumn(table: "dbo.MobDrops", name: "DropsID", newName: "Drops_ID");
            RenameColumn(table: "dbo.Furnaces", name: "OutputSlotID", newName: "OutputSlot_ID");
            RenameColumn(table: "dbo.Brewings", name: "OutputSlotID", newName: "OutputSlot_ID");
        }
    }
}
