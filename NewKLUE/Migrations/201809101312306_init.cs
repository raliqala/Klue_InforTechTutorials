namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audio",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FileSize = c.Int(),
                        FilePath = c.String(),
                        FileContent = c.Binary(),
                        FileDesc = c.String(),
                        CourseName = c.String(),
                        TopicName = c.String(),
                        Media_MediaId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Mediaa", t => t.Media_MediaId)
                .Index(t => t.Media_MediaId);
            
            CreateTable(
                "dbo.Mediaa",
                c => new
                    {
                        MediaId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 128),
                        FileFormat = c.Binary(),
                        FileSize = c.Int(nullable: false),
                        FileDesc = c.String(),
                    })
                .PrimaryKey(t => t.MediaId);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FileSize = c.Int(),
                        FilePath = c.String(),
                        FileContent = c.Binary(),
                        FileDesc = c.String(),
                        CourseName = c.String(),
                        TopicName = c.String(),
                        Media_MediaId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Mediaa", t => t.Media_MediaId)
                .Index(t => t.Media_MediaId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                        Gender = c.String(),
                        Country = c.String(),
                        Region = c.String(),
                        UserBio = c.String(),
                        UserPhoto = c.Binary(),
                        WebUrl = c.String(),
                        CompanyName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.NetWorks",
                c => new
                    {
                        NetWorksId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.NetWorksId);
            
            CreateTable(
                "dbo.Programming",
                c => new
                    {
                        ProgrammingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsCheked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProgrammingId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.Video",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FileSize = c.Int(),
                        FilePath = c.String(),
                        FileContent = c.Binary(),
                        FileDesc = c.String(),
                        CourseName = c.String(),
                        TopicName = c.String(),
                        Media_MediaId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Mediaa", t => t.Media_MediaId)
                .Index(t => t.Media_MediaId);
            
            CreateTable(
                "dbo.ClassRoooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        ClassDesc = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Tutorial",
                c => new
                    {
                        TutorialId = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        CoursesName = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TutorialId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ApplicationUserMedias",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Media_MediaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Media_MediaId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Mediaa", t => t.Media_MediaId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Media_MediaId);
            
            CreateTable(
                "dbo.NetworksApplicationUsers",
                c => new
                    {
                        Networks_NetWorksId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Networks_NetWorksId, t.ApplicationUser_Id })
                .ForeignKey("dbo.NetWorks", t => t.Networks_NetWorksId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Networks_NetWorksId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ProgrammingApplicationUsers",
                c => new
                    {
                        Programming_ProgrammingId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Programming_ProgrammingId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Programming", t => t.Programming_ProgrammingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Programming_ProgrammingId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.SupportServicesApplicationUsers",
                c => new
                    {
                        SupportServices_SupportId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SupportServices_SupportId, t.ApplicationUser_Id })
                .ForeignKey("dbo.SupportServices", t => t.SupportServices_SupportId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.SupportServices_SupportId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutorial", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ClassRoooms", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Video", "Media_MediaId", "dbo.Mediaa");
            DropForeignKey("dbo.SupportServicesApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SupportServicesApplicationUsers", "SupportServices_SupportId", "dbo.SupportServices");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProgrammingApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProgrammingApplicationUsers", "Programming_ProgrammingId", "dbo.Programming");
            DropForeignKey("dbo.NetworksApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NetworksApplicationUsers", "Networks_NetWorksId", "dbo.NetWorks");
            DropForeignKey("dbo.ApplicationUserMedias", "Media_MediaId", "dbo.Mediaa");
            DropForeignKey("dbo.ApplicationUserMedias", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Document", "Media_MediaId", "dbo.Mediaa");
            DropForeignKey("dbo.Audio", "Media_MediaId", "dbo.Mediaa");
            DropIndex("dbo.SupportServicesApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SupportServicesApplicationUsers", new[] { "SupportServices_SupportId" });
            DropIndex("dbo.ProgrammingApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProgrammingApplicationUsers", new[] { "Programming_ProgrammingId" });
            DropIndex("dbo.NetworksApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.NetworksApplicationUsers", new[] { "Networks_NetWorksId" });
            DropIndex("dbo.ApplicationUserMedias", new[] { "Media_MediaId" });
            DropIndex("dbo.ApplicationUserMedias", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Tutorial", new[] { "User_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ClassRoooms", new[] { "User_Id" });
            DropIndex("dbo.Video", new[] { "Media_MediaId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Document", new[] { "Media_MediaId" });
            DropIndex("dbo.Audio", new[] { "Media_MediaId" });
            DropTable("dbo.SupportServicesApplicationUsers");
            DropTable("dbo.ProgrammingApplicationUsers");
            DropTable("dbo.NetworksApplicationUsers");
            DropTable("dbo.ApplicationUserMedias");
            DropTable("dbo.Tutorial");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ClassRoooms");
            DropTable("dbo.Video");
            DropTable("dbo.SupportServices");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Programming");
            DropTable("dbo.NetWorks");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Document");
            DropTable("dbo.Mediaa");
            DropTable("dbo.Audio");
        }
    }
}
