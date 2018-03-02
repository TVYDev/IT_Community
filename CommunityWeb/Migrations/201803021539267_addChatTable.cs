namespace CommunityWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addChatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Body = c.String(),
                        SentDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chats", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Chats", new[] { "User_Id" });
            DropTable("dbo.Chats");
        }
    }
}
