namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init254 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FileName = c.String(),
                        Extension = c.String(),
                        TutorialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tutorial", t => t.TutorialId, cascadeDelete: true)
                .Index(t => t.TutorialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDetails", "TutorialId", "dbo.Tutorial");
            DropIndex("dbo.FileDetails", new[] { "TutorialId" });
            DropTable("dbo.FileDetails");
        }
    }
}
