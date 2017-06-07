namespace BornToCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedResumeOnArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Resume", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Resume");
        }
    }
}
