namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class artistandalbumnavigationproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "ArtistId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "ArtistId");
        }
    }
}
