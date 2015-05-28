namespace timeTracker.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeRegistrationFieldsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Role", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Manager", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Manager", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Role", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Department", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
    }
}
