namespace Forum.DataContexts.ForumsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriesFix : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Forums", "Category_Id", c => c.Int());
            CreateIndex("dbo.Forums", "Category_Id");
            AddForeignKey("dbo.Forums", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Forums", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Forums", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Forums", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Forums", new[] { "Category_Id" });
            DropColumn("dbo.Forums", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
