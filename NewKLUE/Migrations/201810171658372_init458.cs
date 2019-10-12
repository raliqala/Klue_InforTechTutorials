namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init458 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FeedBack", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.FeedBack", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.FeedBack", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Report", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Report", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Report", "Message", c => c.String());
            AlterColumn("dbo.Report", "Email", c => c.String());
            AlterColumn("dbo.FeedBack", "Message", c => c.String());
            AlterColumn("dbo.FeedBack", "Email", c => c.String());
            AlterColumn("dbo.FeedBack", "Name", c => c.String());
        }
    }
}
