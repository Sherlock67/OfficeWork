namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moduleandmenudatatableschemaupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "ModuleId", c => c.Int(nullable: false));
            DropColumn("dbo.Modules", "MenuId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Modules", "MenuId", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "ModuleId");
        }
    }
}
