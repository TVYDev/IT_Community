namespace CommunityWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRequiredAnnotations : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Answers", new[] { "UserId" });
            AlterColumn("dbo.Answers", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Answers", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Answers", new[] { "UserId" });
            AlterColumn("dbo.Answers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Answers", "UserId");
        }
    }
}
