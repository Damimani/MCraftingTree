namespace MCraftingTree.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePathLenghtChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "ImagePath", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "ImagePath", c => c.String(maxLength: 150));
        }
    }
}
