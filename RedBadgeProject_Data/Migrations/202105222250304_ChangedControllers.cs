namespace RedBadgeProject_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedControllers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Song", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Album", "Artist_ArtistId", "dbo.Artist");
            DropIndex("dbo.Album", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Song", new[] { "ArtistId" });
            DropIndex("dbo.Song", new[] { "AlbumId" });
            RenameColumn(table: "dbo.Song", name: "AlbumId", newName: "Album_AlbumId");
            RenameColumn(table: "dbo.Album", name: "Artist_ArtistId", newName: "ArtistId");
            AddColumn("dbo.Album", "SongId", c => c.Int(nullable: false));
            AlterColumn("dbo.Album", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Song", "ArtistId", c => c.Int());
            AlterColumn("dbo.Song", "Album_AlbumId", c => c.Int());
            CreateIndex("dbo.Album", "ArtistId");
            CreateIndex("dbo.Album", "SongId");
            CreateIndex("dbo.Song", "ArtistId");
            CreateIndex("dbo.Song", "Album_AlbumId");
            AddForeignKey("dbo.Album", "SongId", "dbo.Song", "SongId", cascadeDelete: true);
            AddForeignKey("dbo.Song", "Album_AlbumId", "dbo.Album", "AlbumId");
            AddForeignKey("dbo.Song", "ArtistId", "dbo.Artist", "ArtistId");
            AddForeignKey("dbo.Album", "ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
            DropColumn("dbo.Song", "ArtistName");
            DropColumn("dbo.Song", "GenreName");
            DropColumn("dbo.Song", "AlbumName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Song", "AlbumName", c => c.String());
            AddColumn("dbo.Song", "GenreName", c => c.String());
            AddColumn("dbo.Song", "ArtistName", c => c.String());
            DropForeignKey("dbo.Album", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Song", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Song", "Album_AlbumId", "dbo.Album");
            DropForeignKey("dbo.Album", "SongId", "dbo.Song");
            DropIndex("dbo.Song", new[] { "Album_AlbumId" });
            DropIndex("dbo.Song", new[] { "ArtistId" });
            DropIndex("dbo.Album", new[] { "SongId" });
            DropIndex("dbo.Album", new[] { "ArtistId" });
            AlterColumn("dbo.Song", "Album_AlbumId", c => c.Int(nullable: false));
            AlterColumn("dbo.Song", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Album", "ArtistId", c => c.Int());
            DropColumn("dbo.Album", "SongId");
            RenameColumn(table: "dbo.Album", name: "ArtistId", newName: "Artist_ArtistId");
            RenameColumn(table: "dbo.Song", name: "Album_AlbumId", newName: "AlbumId");
            CreateIndex("dbo.Song", "AlbumId");
            CreateIndex("dbo.Song", "ArtistId");
            CreateIndex("dbo.Album", "Artist_ArtistId");
            AddForeignKey("dbo.Album", "Artist_ArtistId", "dbo.Artist", "ArtistId");
            AddForeignKey("dbo.Song", "ArtistId", "dbo.Artist", "ArtistId", cascadeDelete: true);
            AddForeignKey("dbo.Song", "AlbumId", "dbo.Album", "AlbumId", cascadeDelete: true);
        }
    }
}
