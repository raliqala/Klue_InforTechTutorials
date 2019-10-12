namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updater21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedBack", "Title", c => c.String(nullable: false));
            AddColumn("dbo.FeedBack", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Report", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Report", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Report", "DateTime");
            DropColumn("dbo.Report", "Title");
            DropColumn("dbo.FeedBack", "DateTime");
            DropColumn("dbo.FeedBack", "Title");
        }
    }
}
