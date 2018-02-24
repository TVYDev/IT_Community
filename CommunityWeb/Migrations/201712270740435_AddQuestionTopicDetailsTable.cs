namespace CommunityWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionTopicDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionTopicDetails",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.TopicId })
                .ForeignKey("dbo.Questions", t => t.QuestionId)
                .ForeignKey("dbo.Topics", t => t.TopicId)
                .Index(t => t.QuestionId)
                .Index(t => t.TopicId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionTopicDetails", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.QuestionTopicDetails", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionTopicDetails", new[] { "TopicId" });
            DropIndex("dbo.QuestionTopicDetails", new[] { "QuestionId" });
            DropTable("dbo.QuestionTopicDetails");
        }
    }
}
