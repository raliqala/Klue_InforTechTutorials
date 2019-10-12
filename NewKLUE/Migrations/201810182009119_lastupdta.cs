namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastupdta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileDetails", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileDetails", "Date");
        }
    }
}
