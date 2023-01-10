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
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 150),
                        Brewing_Id = c.Int(),
                        Brewing_Id1 = c.Int(),
                        CraftingTable_Id = c.Int(),
                        CraftingTable_Id1 = c.Int(),
                        CraftingTable_Id2 = c.Int(),
                        CraftingTable_Id3 = c.Int(),
                        CraftingTable_Id4 = c.Int(),
                        CraftingTable_Id5 = c.Int(),
                        CraftingTable_Id6 = c.Int(),
                        CraftingTable_Id7 = c.Int(),
                        CraftingTable_Id8 = c.Int(),
                        CraftingTable_Id9 = c.Int(),
                        Furnace_Id = c.Int(),
                        Furnace_Id1 = c.Int(),
                        MobDrops_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brewings", t => t.Brewing_Id)
                .ForeignKey("dbo.Brewings", t => t.Brewing_Id1)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id1)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id2)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id3)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id4)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id5)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id6)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id7)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id8)
                .ForeignKey("dbo.CraftingTables", t => t.CraftingTable_Id9)
                .ForeignKey("dbo.Furnaces", t => t.Furnace_Id)
                .ForeignKey("dbo.Furnaces", t => t.Furnace_Id1)
                .ForeignKey("dbo.MobDrops", t => t.MobDrops_Id)
                .Index(t => t.Brewing_Id)
                .Index(t => t.Brewing_Id1)
                .Index(t => t.CraftingTable_Id)
                .Index(t => t.CraftingTable_Id1)
                .Index(t => t.CraftingTable_Id2)
                .Index(t => t.CraftingTable_Id3)
                .Index(t => t.CraftingTable_Id4)
                .Index(t => t.CraftingTable_Id5)
                .Index(t => t.CraftingTable_Id6)
                .Index(t => t.CraftingTable_Id7)
                .Index(t => t.CraftingTable_Id8)
                .Index(t => t.CraftingTable_Id9)
                .Index(t => t.Furnace_Id)
                .Index(t => t.Furnace_Id1)
                .Index(t => t.MobDrops_Id);
            
            CreateTable(
                "dbo.CraftingTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Furnaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MobDrops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DropChance = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Mobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        MobDrops_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MobDrops", t => t.MobDrops_Id)
                .Index(t => t.MobDrops_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mobs", "MobDrops_Id", "dbo.MobDrops");
            DropForeignKey("dbo.Items", "MobDrops_Id", "dbo.MobDrops");
            DropForeignKey("dbo.Items", "Furnace_Id1", "dbo.Furnaces");
            DropForeignKey("dbo.Items", "Furnace_Id", "dbo.Furnaces");
            DropForeignKey("dbo.Items", "CraftingTable_Id9", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id8", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id7", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id6", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id5", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id4", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id3", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id2", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id1", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "CraftingTable_Id", "dbo.CraftingTables");
            DropForeignKey("dbo.Items", "Brewing_Id1", "dbo.Brewings");
            DropForeignKey("dbo.Items", "Brewing_Id", "dbo.Brewings");
            DropIndex("dbo.Mobs", new[] { "MobDrops_Id" });
            DropIndex("dbo.Items", new[] { "MobDrops_Id" });
            DropIndex("dbo.Items", new[] { "Furnace_Id1" });
            DropIndex("dbo.Items", new[] { "Furnace_Id" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id9" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id8" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id7" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id6" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id5" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id4" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id3" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id2" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id1" });
            DropIndex("dbo.Items", new[] { "CraftingTable_Id" });
            DropIndex("dbo.Items", new[] { "Brewing_Id1" });
            DropIndex("dbo.Items", new[] { "Brewing_Id" });
            DropTable("dbo.Mobs");
            DropTable("dbo.MobDrops");
            DropTable("dbo.Furnaces");
            DropTable("dbo.CraftingTables");
            DropTable("dbo.Items");
            DropTable("dbo.Brewings");
        }
    }
}
