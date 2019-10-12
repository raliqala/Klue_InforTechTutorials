namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tutorial", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tutorial", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
