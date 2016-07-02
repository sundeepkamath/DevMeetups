namespace DevMeetups.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCancelledToMeetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetups", "IsCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetups", "IsCancelled");
        }
    }
}
