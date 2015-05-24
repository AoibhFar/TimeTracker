namespace timeTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpectedHoursandActualHours : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ExpectedHours", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ActualHours", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ActualHours");
            DropColumn("dbo.Projects", "ExpectedHours");
        }
    }
}
