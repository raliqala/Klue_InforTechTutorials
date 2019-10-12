namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevotelog : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Audio", "Media_MediaId", "dbo.Mediaa");
            DropForeignKey("dbo.Document", "Media_MediaId", "dbo.Mediaa");
            DropForeignKey("dbo.ApplicationUserMedias", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserMedias", "Media_MediaId", "dbo.Mediaa");
            DropForeignKey("dbo.Video", "Media_MediaId", "dbo.Mediaa");
            DropIndex("dbo.Audio", new[] { "Media_MediaId" });
            DropIndex("dbo.Document", new[] { "Media_MediaId" });
            DropIndex("dbo.Video", new[] { "Media_MediaId" });
            DropIndex("dbo.ApplicationUserMedias", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserMedias", new[] { "Media_MediaId" });
            CreateTable(
                "dbo.VoteLog",
                c => new
                    {
                        VoteId = c.Int(nullable: false, identity: true),
                        SectionId = c.Short(nullable: false),
                        VoteForId = c.Int(nullable: false),
                        UserName = c.String(),
                        Vote = c.Short(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VoteId);
            
            AddColumn("dbo.Tutorial", "Votes", c => c.String(maxLength: 50));
            DropTable("dbo.Audio");
            DropTable("dbo.Mediaa");
            DropTable("dbo.Document");
            DropTable("dbo.Video");
            DropTable("dbo.ApplicationUserMedias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserMedias",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Media_MediaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Media_MediaId });
            
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Tutorial", "Votes");
            DropTable("dbo.VoteLog");
            CreateIndex("dbo.ApplicationUserMedias", "Media_MediaId");
            CreateIndex("dbo.ApplicationUserMedias", "ApplicationUser_Id");
            CreateIndex("dbo.Video", "Media_MediaId");
            CreateIndex("dbo.Document", "Media_MediaId");
            CreateIndex("dbo.Audio", "Media_MediaId");
            AddForeignKey("dbo.Video", "Media_MediaId", "dbo.Mediaa", "MediaId");
            AddForeignKey("dbo.ApplicationUserMedias", "Media_MediaId", "dbo.Mediaa", "MediaId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserMedias", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Document", "Media_MediaId", "dbo.Mediaa", "MediaId");
            AddForeignKey("dbo.Audio", "Media_MediaId", "dbo.Mediaa", "MediaId");
        }
    }
}
