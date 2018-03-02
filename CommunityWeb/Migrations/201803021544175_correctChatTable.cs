namespace CommunityWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctChatTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Chats", new[] { "User_Id" });
            DropColumn("dbo.Chats", "UserId");
            RenameColumn(table: "dbo.Chats", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Chats", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Chats", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Chats", new[] { "UserId" });
            AlterColumn("dbo.Chats", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Chats", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Chats", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Chats", "User_Id");
        }
    }
}
