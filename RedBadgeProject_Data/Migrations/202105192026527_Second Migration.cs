namespace RedBadgeProject_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Song", "ArtistName", c => c.String());
            AddColumn("dbo.Song", "GenreName", c => c.String());
            AddColumn("dbo.Song", "AlbumName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Song", "AlbumName");
            DropColumn("dbo.Song", "GenreName");
            DropColumn("dbo.Song", "ArtistName");
        }
    }
}
