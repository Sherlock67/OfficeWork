namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moduleidnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserPermissions", "ModuleId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserPermissions", "ModuleId", c => c.Int(nullable: false));
        }
    }
}
