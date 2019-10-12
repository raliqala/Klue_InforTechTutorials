namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tutorial", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tutorial", new[] { "User_Id" });
            AlterColumn("dbo.Tutorial", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tutorial", "User_Id");
            AddForeignKey("dbo.Tutorial", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutorial", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tutorial", new[] { "User_Id" });
            AlterColumn("dbo.Tutorial", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tutorial", "User_Id");
            AddForeignKey("dbo.Tutorial", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
