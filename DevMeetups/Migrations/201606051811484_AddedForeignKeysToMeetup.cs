namespace DevMeetups.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeysToMeetup : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Meetups", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Meetups", name: "Developer_Id", newName: "DeveloperId");
            RenameIndex(table: "dbo.Meetups", name: "IX_Developer_Id", newName: "IX_DeveloperId");
            RenameIndex(table: "dbo.Meetups", name: "IX_Category_Id", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Meetups", name: "IX_CategoryId", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.Meetups", name: "IX_DeveloperId", newName: "IX_Developer_Id");
            RenameColumn(table: "dbo.Meetups", name: "DeveloperId", newName: "Developer_Id");
            RenameColumn(table: "dbo.Meetups", name: "CategoryId", newName: "Category_Id");
        }
    }
}
