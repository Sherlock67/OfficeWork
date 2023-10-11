namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relationshipmodified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_ArtistId" });
            RenameColumn(table: "dbo.Albums", name: "Artist_ArtistId", newName: "ArtistId");
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "ArtistId");
            AddForeignKey("dbo.Albums", "ArtistId", "dbo.Artists", "ArtistId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "ArtistId" });
            AlterColumn("dbo.Albums", "ArtistId", c => c.Int());
            RenameColumn(table: "dbo.Albums", name: "ArtistId", newName: "Artist_ArtistId");
            CreateIndex("dbo.Albums", "Artist_ArtistId");
            AddForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists", "ArtistId");
        }
    }
}
