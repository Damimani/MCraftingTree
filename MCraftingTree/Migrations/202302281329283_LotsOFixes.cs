namespace MCraftingTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LotsOFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MobDrops", "MobId_ID", "dbo.Items");
            DropForeignKey("dbo.MobDrops", "Drops_ID", "dbo.Items");
            DropForeignKey("dbo.Brewings", "IngredientSlot_ID", "dbo.Items");
            DropForeignKey("dbo.Brewings", "OutputSlot_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "OutputSlot_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot11_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot12_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot13_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot21_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot22_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot23_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot31_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot32_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot33_ID", "dbo.Items");
            DropForeignKey("dbo.Furnaces", "InputSlot_ID", "dbo.Items");
            DropForeignKey("dbo.Furnaces", "OutputSlot_ID", "dbo.Items");
            DropIndex("dbo.Brewings", new[] { "IngredientSlot_ID" });
            DropIndex("dbo.Brewings", new[] { "OutputSlot_ID" });
            DropIndex("dbo.CraftingTables", new[] { "OutputSlot_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot11_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot12_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot13_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot21_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot22_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot23_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot31_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot32_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot33_ID" });
            DropIndex("dbo.Furnaces", new[] { "InputSlot_ID" });
            DropIndex("dbo.Furnaces", new[] { "OutputSlot_ID" });
            DropIndex("dbo.MobDrops", new[] { "Drops_ID" });
            DropIndex("dbo.MobDrops", new[] { "MobId_ID" });
            DropPrimaryKey("dbo.Items");
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        Type = c.String(maxLength: 50),
                        Item_ID = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.Item_ID, cascadeDelete: true)
                .Index(t => t.Item_ID);
            
            AddColumn("dbo.MobDrops", "MobName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Brewings", "IngredientSlot_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.Brewings", "OutputSlot_ID", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Items", "ID", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Items", "ImagePath", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "OutputSlot_ID", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot11_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot12_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot13_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot21_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot22_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot23_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot31_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot32_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.CraftingTables", "Slot33_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.Furnaces", "InputSlot_ID", c => c.String(maxLength: 100));
            AlterColumn("dbo.Furnaces", "OutputSlot_ID", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.MobDrops", "Drops_ID", c => c.String(nullable: false, maxLength: 100));
            AddPrimaryKey("dbo.Items", "ID");
            CreateIndex("dbo.Brewings", "IngredientSlot_ID");
            CreateIndex("dbo.Brewings", "OutputSlot_ID");
            CreateIndex("dbo.CraftingTables", "OutputSlot_ID");
            CreateIndex("dbo.CraftingTables", "Slot11_ID");
            CreateIndex("dbo.CraftingTables", "Slot12_ID");
            CreateIndex("dbo.CraftingTables", "Slot13_ID");
            CreateIndex("dbo.CraftingTables", "Slot21_ID");
            CreateIndex("dbo.CraftingTables", "Slot22_ID");
            CreateIndex("dbo.CraftingTables", "Slot23_ID");
            CreateIndex("dbo.CraftingTables", "Slot31_ID");
            CreateIndex("dbo.CraftingTables", "Slot32_ID");
            CreateIndex("dbo.CraftingTables", "Slot33_ID");
            CreateIndex("dbo.Furnaces", "InputSlot_ID");
            CreateIndex("dbo.Furnaces", "OutputSlot_ID");
            CreateIndex("dbo.MobDrops", "Drops_ID");
            AddForeignKey("dbo.MobDrops", "Drops_ID", "dbo.Items", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Brewings", "IngredientSlot_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.Brewings", "OutputSlot_ID", "dbo.Items", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CraftingTables", "OutputSlot_ID", "dbo.Items", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CraftingTables", "Slot11_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot12_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot13_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot21_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot22_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot23_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot31_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot32_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot33_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.Furnaces", "InputSlot_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.Furnaces", "OutputSlot_ID", "dbo.Items", "ID", cascadeDelete: true);
            DropColumn("dbo.Items", "Type");
            DropColumn("dbo.MobDrops", "MobId_ID");
            DropTable("dbo.Mobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Mobs",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.MobDrops", "MobId_ID", c => c.String(nullable: false, maxLength: 36));
            AddColumn("dbo.Items", "Type", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Furnaces", "OutputSlot_ID", "dbo.Items");
            DropForeignKey("dbo.Furnaces", "InputSlot_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot33_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot32_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot31_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot23_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot22_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot21_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot13_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot12_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "Slot11_ID", "dbo.Items");
            DropForeignKey("dbo.CraftingTables", "OutputSlot_ID", "dbo.Items");
            DropForeignKey("dbo.Brewings", "OutputSlot_ID", "dbo.Items");
            DropForeignKey("dbo.Brewings", "IngredientSlot_ID", "dbo.Items");
            DropForeignKey("dbo.MobDrops", "Drops_ID", "dbo.Items");
            DropForeignKey("dbo.Types", "Item_ID", "dbo.Items");
            DropIndex("dbo.Types", new[] { "Item_ID" });
            DropIndex("dbo.MobDrops", new[] { "Drops_ID" });
            DropIndex("dbo.Furnaces", new[] { "OutputSlot_ID" });
            DropIndex("dbo.Furnaces", new[] { "InputSlot_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot33_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot32_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot31_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot23_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot22_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot21_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot13_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot12_ID" });
            DropIndex("dbo.CraftingTables", new[] { "Slot11_ID" });
            DropIndex("dbo.CraftingTables", new[] { "OutputSlot_ID" });
            DropIndex("dbo.Brewings", new[] { "OutputSlot_ID" });
            DropIndex("dbo.Brewings", new[] { "IngredientSlot_ID" });
            DropPrimaryKey("dbo.Items");
            AlterColumn("dbo.MobDrops", "Drops_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.Furnaces", "OutputSlot_ID", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.Furnaces", "InputSlot_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot33_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot32_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot31_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot23_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot22_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot21_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot13_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot12_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "Slot11_ID", c => c.String(maxLength: 36));
            AlterColumn("dbo.CraftingTables", "OutputSlot_ID", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.Items", "ImagePath", c => c.String(maxLength: 250));
            AlterColumn("dbo.Items", "ID", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.Brewings", "OutputSlot_ID", c => c.String(nullable: false, maxLength: 36));
            AlterColumn("dbo.Brewings", "IngredientSlot_ID", c => c.String(maxLength: 36));
            DropColumn("dbo.MobDrops", "MobName");
            DropTable("dbo.Types");
            AddPrimaryKey("dbo.Items", "ID");
            CreateIndex("dbo.MobDrops", "MobId_ID");
            CreateIndex("dbo.MobDrops", "Drops_ID");
            CreateIndex("dbo.Furnaces", "OutputSlot_ID");
            CreateIndex("dbo.Furnaces", "InputSlot_ID");
            CreateIndex("dbo.CraftingTables", "Slot33_ID");
            CreateIndex("dbo.CraftingTables", "Slot32_ID");
            CreateIndex("dbo.CraftingTables", "Slot31_ID");
            CreateIndex("dbo.CraftingTables", "Slot23_ID");
            CreateIndex("dbo.CraftingTables", "Slot22_ID");
            CreateIndex("dbo.CraftingTables", "Slot21_ID");
            CreateIndex("dbo.CraftingTables", "Slot13_ID");
            CreateIndex("dbo.CraftingTables", "Slot12_ID");
            CreateIndex("dbo.CraftingTables", "Slot11_ID");
            CreateIndex("dbo.CraftingTables", "OutputSlot_ID");
            CreateIndex("dbo.Brewings", "OutputSlot_ID");
            CreateIndex("dbo.Brewings", "IngredientSlot_ID");
            AddForeignKey("dbo.Furnaces", "OutputSlot_ID", "dbo.Items", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Furnaces", "InputSlot_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot33_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot32_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot31_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot23_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot22_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot21_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot13_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot12_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "Slot11_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CraftingTables", "OutputSlot_ID", "dbo.Items", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Brewings", "OutputSlot_ID", "dbo.Items", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Brewings", "IngredientSlot_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.MobDrops", "Drops_ID", "dbo.Items", "ID");
            AddForeignKey("dbo.MobDrops", "MobId_ID", "dbo.Items", "ID", cascadeDelete: true);
        }
    }
}
