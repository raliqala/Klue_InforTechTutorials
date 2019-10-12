namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init45 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tutorial", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tutorial", "CreatedOn");
        }
    }
}
