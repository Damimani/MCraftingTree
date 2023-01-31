namespace MCraftingTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brewings",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        IngredientSlot_ID = c.String(maxLength: 36),
                        OutputSlot_ID = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.IngredientSlot_ID)
                .ForeignKey("dbo.Items", t => t.OutputSlot_ID, cascadeDelete: true)
                .Index(t => t.IngredientSlot_ID)
                .Index(t => t.OutputSlot_ID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        Type = c.String(maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CraftingTables",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        OutputSlot_ID = c.String(nullable: false, maxLength: 36),
                        Slot11_ID = c.String(maxLength: 36),
                        Slot12_ID = c.String(maxLength: 36),
                        Slot13_ID = c.String(maxLength: 36),
                        Slot21_ID = c.String(maxLength: 36),
                        Slot22_ID = c.String(maxLength: 36),
                        Slot23_ID = c.String(maxLength: 36),
                        Slot31_ID = c.String(maxLength: 36),
                        Slot32_ID = c.String(maxLength: 36),
                        Slot33_ID = c.String(maxLength: 36),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.OutputSlot_ID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Slot11_ID)
                .ForeignKey("dbo.Items", t => t.Slot12_ID)
                .ForeignKey("dbo.Items", t => t.Slot13_ID)
                .ForeignKey("dbo.Items", t => t.Slot21_ID)
                .ForeignKey("dbo.Items", t => t.Slot22_ID)
                .ForeignKey("dbo.Items", t => t.Slot23_ID)
                .ForeignKey("dbo.Items", t => t.Slot31_ID)
                .ForeignKey("dbo.Items", t => t.Slot32_ID)
                .ForeignKey("dbo.Items", t => t.Slot33_ID)
                .Index(t => t.OutputSlot_ID)
                .Index(t => t.Slot11_ID)
                .Index(t => t.Slot12_ID)
                .Index(t => t.Slot13_ID)
                .Index(t => t.Slot21_ID)
                .Index(t => t.Slot22_ID)
                .Index(t => t.Slot23_ID)
                .Index(t => t.Slot31_ID)
                .Index(t => t.Slot32_ID)
                .Index(t => t.Slot33_ID);
            
            CreateTable(
                "dbo.Furnaces",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        InputSlot_ID = c.String(maxLength: 36),
                        OutputSlot_ID = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.InputSlot_ID)
                .ForeignKey("dbo.Items", t => t.OutputSlot_ID, cascadeDelete: true)
                .Index(t => t.InputSlot_ID)
                .Index(t => t.OutputSlot_ID);
            
            CreateTable(
                "dbo.MobDrops",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        DropChance = c.Double(nullable: false),
                        Drops_ID = c.String(maxLength: 36),
                        MobId_ID = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.Drops_ID)
                .ForeignKey("dbo.Items", t => t.MobId_ID, cascadeDelete: true)
                .Index(t => t.Drops_ID)
                .Index(t => t.MobId_ID);
            
            CreateTable(
                "dbo.Mobs",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 36),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MobDrops", "MobId_ID", "dbo.Items");
            DropForeignKey("dbo.MobDrops", "Drops_ID", "dbo.Items");
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
            DropIndex("dbo.MobDrops", new[] { "MobId_ID" });
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
            DropTable("dbo.Mobs");
            DropTable("dbo.MobDrops");
            DropTable("dbo.Furnaces");
            DropTable("dbo.CraftingTables");
            DropTable("dbo.Items");
            DropTable("dbo.Brewings");
        }
    }
}
