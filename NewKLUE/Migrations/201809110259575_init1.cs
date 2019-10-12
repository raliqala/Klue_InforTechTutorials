namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tutorial", "CoursesName", c => c.String(nullable: false));
            AlterColumn("dbo.Tutorial", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tutorial", "Description", c => c.String());
            AlterColumn("dbo.Tutorial", "CoursesName", c => c.String());
        }
    }
}
