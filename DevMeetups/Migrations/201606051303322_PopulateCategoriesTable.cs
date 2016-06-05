namespace DevMeetups.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(Id, Name) VALUES(1, 'Programming Language')");
            Sql("INSERT INTO Categories(Id, Name) VALUES(2, 'Framework')");
            Sql("INSERT INTO Categories(Id, Name) VALUES(3, 'Design Patterns')");
            Sql("INSERT INTO Categories(Id, Name) VALUES(4, 'Coding Practices')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1,2,3,4)");
        }
    }
}
