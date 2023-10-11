namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class artistandalbum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Artist_ArtistId", c => c.Int());
            CreateIndex("dbo.Albums", "Artist_ArtistId");
            AddForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists", "ArtistId");
            DropColumn("dbo.Albums", "ArtistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "ArtistId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_ArtistId" });
            DropColumn("dbo.Albums", "Artist_ArtistId");
        }
    }
}
