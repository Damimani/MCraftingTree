namespace MCraftingTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ImagePath", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ImagePath");
        }
    }
}
