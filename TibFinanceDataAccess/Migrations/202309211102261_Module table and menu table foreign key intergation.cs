namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moduletableandmenutableforeignkeyintergation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Modules", "MenuId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Modules", "MenuId");
        }
    }
}
