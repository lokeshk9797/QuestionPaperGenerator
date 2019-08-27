namespace QuestionPaperGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorksheetDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Frequency = c.Int(nullable: false),
                        Marks = c.Int(nullable: false),
                        Template_Id = c.Int(nullable: false),
                        Worksheet_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TemplateMaster", t => t.Template_Id, cascadeDelete: true)
                .ForeignKey("dbo.WorksheetMaster", t => t.Worksheet_Id, cascadeDelete: true)
                .Index(t => t.Template_Id)
                .Index(t => t.Worksheet_Id);
            
            CreateTable(
                "dbo.TemplateMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Formula = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemplateDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MinValue = c.Int(nullable: false),
                        MaxValue = c.Int(nullable: false),
                        Template_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TemplateMaster", t => t.Template_Id, cascadeDelete: true)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.WorksheetMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorksheetName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorksheetDetails", "Worksheet_Id", "dbo.WorksheetMaster");
            DropForeignKey("dbo.WorksheetDetails", "Template_Id", "dbo.TemplateMaster");
            DropForeignKey("dbo.TemplateDetails", "Template_Id", "dbo.TemplateMaster");
            DropIndex("dbo.TemplateDetails", new[] { "Template_Id" });
            DropIndex("dbo.WorksheetDetails", new[] { "Worksheet_Id" });
            DropIndex("dbo.WorksheetDetails", new[] { "Template_Id" });
            DropTable("dbo.WorksheetMaster");
            DropTable("dbo.TemplateDetails");
            DropTable("dbo.TemplateMaster");
            DropTable("dbo.WorksheetDetails");
        }
    }
}
