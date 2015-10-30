namespace Forum.DataContexts.PostsMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Thread_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Threads", t => t.Thread_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Thread_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        Category = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "Thread_Id", "dbo.Threads");
            DropForeignKey("dbo.Threads", "User_Id", "dbo.Users");
            DropIndex("dbo.Threads", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "User_Id" });
            DropIndex("dbo.Posts", new[] { "Thread_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Threads");
            DropTable("dbo.Posts");
        }
    }
}
