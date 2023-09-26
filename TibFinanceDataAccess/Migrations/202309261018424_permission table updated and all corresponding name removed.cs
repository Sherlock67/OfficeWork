namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class permissiontableupdatedandallcorrespondingnameremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserPermissions", "ModuleName");
            DropColumn("dbo.UserPermissions", "MenuName");
            DropColumn("dbo.UserPermissions", "UserName");
            DropColumn("dbo.UserPermissions", "RoleName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPermissions", "RoleName", c => c.String());
            AddColumn("dbo.UserPermissions", "UserName", c => c.String());
            AddColumn("dbo.UserPermissions", "MenuName", c => c.String());
            AddColumn("dbo.UserPermissions", "ModuleName", c => c.String());
        }
    }
}
