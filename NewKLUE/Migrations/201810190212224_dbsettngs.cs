namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsettngs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Facebook", c => c.String());
            AddColumn("dbo.AspNetUsers", "Twitter", c => c.String());
            AddColumn("dbo.AspNetUsers", "YouTube", c => c.String());
            AddColumn("dbo.AspNetUsers", "GitHub", c => c.String());
            AddColumn("dbo.AspNetUsers", "Dribble", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Dribble");
            DropColumn("dbo.AspNetUsers", "GitHub");
            DropColumn("dbo.AspNetUsers", "YouTube");
            DropColumn("dbo.AspNetUsers", "Twitter");
            DropColumn("dbo.AspNetUsers", "Facebook");
        }
    }
}
