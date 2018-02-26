namespace CommunityWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Answer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 255),
                        QuestionId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        ImageUrls = c.String(),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Answers");
        }
    }
}
