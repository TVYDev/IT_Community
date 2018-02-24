namespace CommunityWeb.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTopicsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Topics(Name) VALUES('C#')");
            Sql("INSERT INTO Topics(Name) VALUES('Java')");
            Sql("INSERT INTO Topics(Name) VALUES('Swift')");
            Sql("INSERT INTO Topics(Name) VALUES('HTML')");
            Sql("INSERT INTO Topics(Name) VALUES('CSS')");
            Sql("INSERT INTO Topics(Name) VALUES('JavaScript')");
            Sql("INSERT INTO Topics(Name) VALUES('ASP.NET')");
            Sql("INSERT INTO Topics(Name) VALUES('PHP')");
            Sql("INSERT INTO Topics(Name) VALUES('Python')");
            Sql("INSERT INTO Topics(Name) VALUES('C++')");
        }
        
        public override void Down()
        {
        }
    }
}
