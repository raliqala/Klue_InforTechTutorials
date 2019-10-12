namespace NewKLUE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbackandreport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBack",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Message = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Message = c.String(),
                        IsChecked = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeedBackApplicationUsers",
                c => new
                    {
                        FeedBack_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FeedBack_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.FeedBack", t => t.FeedBack_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.FeedBack_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ReportProblemApplicationUsers",
                c => new
                    {
                        ReportProblem_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ReportProblem_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Report", t => t.ReportProblem_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.ReportProblem_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportProblemApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReportProblemApplicationUsers", "ReportProblem_Id", "dbo.Report");
            DropForeignKey("dbo.FeedBackApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FeedBackApplicationUsers", "FeedBack_Id", "dbo.FeedBack");
            DropIndex("dbo.ReportProblemApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ReportProblemApplicationUsers", new[] { "ReportProblem_Id" });
            DropIndex("dbo.FeedBackApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FeedBackApplicationUsers", new[] { "FeedBack_Id" });
            DropTable("dbo.ReportProblemApplicationUsers");
            DropTable("dbo.FeedBackApplicationUsers");
            DropTable("dbo.Report");
            DropTable("dbo.FeedBack");
        }
    }
}
