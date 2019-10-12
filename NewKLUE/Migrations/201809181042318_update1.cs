namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tutorial", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Tutorial", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tutorial", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Tutorial", name: "UserId", newName: "User_Id");
        }
    }
}
