namespace RedBadgeProject_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreDebugging : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rating", "Rating_RatingId", c => c.Int());
            CreateIndex("dbo.Rating", "Rating_RatingId");
            AddForeignKey("dbo.Rating", "Rating_RatingId", "dbo.Rating", "RatingId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "Rating_RatingId", "dbo.Rating");
            DropIndex("dbo.Rating", new[] { "Rating_RatingId" });
            DropColumn("dbo.Rating", "Rating_RatingId");
        }
    }
}
