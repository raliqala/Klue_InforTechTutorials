namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NetworksApplicationUsers", "Networks_NetWorksId", "dbo.NetWorks");
            DropForeignKey("dbo.NetworksApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProgrammingApplicationUsers", "Programming_ProgrammingId", "dbo.Programming");
            DropForeignKey("dbo.ProgrammingApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SupportServicesApplicationUsers", "SupportServices_SupportId", "dbo.SupportServices");
            DropForeignKey("dbo.SupportServicesApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.NetworksApplicationUsers", new[] { "Networks_NetWorksId" });
            DropIndex("dbo.NetworksApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProgrammingApplicationUsers", new[] { "Programming_ProgrammingId" });
            DropIndex("dbo.ProgrammingApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SupportServicesApplicationUsers", new[] { "SupportServices_SupportId" });
            DropIndex("dbo.SupportServicesApplicationUsers", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.TutorToProgramming",
                c => new
                    {
                        TutorToProgrammingId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ProgrammingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TutorToProgrammingId)
                .ForeignKey("dbo.Programming", t => t.ProgrammingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProgrammingId);
            
            AddColumn("dbo.Tutorial", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Programming", "IsCheked");
            DropTable("dbo.NetWorks");
            DropTable("dbo.SupportServices");
            DropTable("dbo.NetworksApplicationUsers");
            DropTable("dbo.ProgrammingApplicationUsers");
            DropTable("dbo.SupportServicesApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SupportServicesApplicationUsers",
                c => new
                    {
                        SupportServices_SupportId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SupportServices_SupportId, t.ApplicationUser_Id });
            
            CreateTable(
                "dbo.ProgrammingApplicationUsers",
                c => new
                    {
                        Programming_ProgrammingId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Programming_ProgrammingId, t.ApplicationUser_Id });
            
            CreateTable(
                "dbo.NetworksApplicationUsers",
                c => new
                    {
                        Networks_NetWorksId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Networks_NetWorksId, t.ApplicationUser_Id });
            
            CreateTable(
                "dbo.SupportServices",
                c => new
                    {
                        SupportId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SupportId);
            
            CreateTable(
                "dbo.NetWorks",
                c => new
                    {
                        NetWorksId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NetWorksId);
            
            AddColumn("dbo.Programming", "IsCheked", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.TutorToProgramming", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TutorToProgramming", "ProgrammingId", "dbo.Programming");
            DropIndex("dbo.TutorToProgramming", new[] { "ProgrammingId" });
            DropIndex("dbo.TutorToProgramming", new[] { "UserId" });
            DropColumn("dbo.Tutorial", "CreatedOn");
            DropTable("dbo.TutorToProgramming");
            CreateIndex("dbo.SupportServicesApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.SupportServicesApplicationUsers", "SupportServices_SupportId");
            CreateIndex("dbo.ProgrammingApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.ProgrammingApplicationUsers", "Programming_ProgrammingId");
            CreateIndex("dbo.NetworksApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.NetworksApplicationUsers", "Networks_NetWorksId");
            AddForeignKey("dbo.SupportServicesApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SupportServicesApplicationUsers", "SupportServices_SupportId", "dbo.SupportServices", "SupportId", cascadeDelete: true);
            AddForeignKey("dbo.ProgrammingApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProgrammingApplicationUsers", "Programming_ProgrammingId", "dbo.Programming", "ProgrammingId", cascadeDelete: true);
            AddForeignKey("dbo.NetworksApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NetworksApplicationUsers", "Networks_NetWorksId", "dbo.NetWorks", "NetWorksId", cascadeDelete: true);
        }
    }
}
