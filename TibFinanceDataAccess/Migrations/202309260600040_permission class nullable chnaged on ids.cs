namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permissionclassnullablechnagedonids : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserPermissions", "MenuId", c => c.Int());
            AlterColumn("dbo.UserPermissions", "UserId", c => c.Int());
            AlterColumn("dbo.UserPermissions", "RoleId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserPermissions", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserPermissions", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserPermissions", "MenuId", c => c.Int(nullable: false));
        }
    }
}
