namespace DevMeetups.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMeetupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meetups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Category_Id = c.Byte(),
                        Developer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Developer_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Developer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetups", "Developer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetups", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Meetups", new[] { "Developer_Id" });
            DropIndex("dbo.Meetups", new[] { "Category_Id" });
            DropTable("dbo.Meetups");
            DropTable("dbo.Categories");
        }
    }
}
