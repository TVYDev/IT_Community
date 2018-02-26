namespace CommunityWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25022018 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Answers", "UserId");
            AddForeignKey("dbo.Answers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Answers", new[] { "UserId" });
            AlterColumn("dbo.Answers", "UserId", c => c.String(maxLength: 255));
        }
    }
}
