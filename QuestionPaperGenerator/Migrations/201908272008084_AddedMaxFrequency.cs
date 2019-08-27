namespace QuestionPaperGenerator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaxFrequency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TemplateMaster", "MaxFrequency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TemplateMaster", "MaxFrequency");
        }
    }
}
