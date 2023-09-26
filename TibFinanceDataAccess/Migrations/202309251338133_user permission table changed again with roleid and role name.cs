namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpermissiontablechangedagainwithroleidandrolename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPermissions", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.UserPermissions", "RoleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPermissions", "RoleName");
            DropColumn("dbo.UserPermissions", "RoleId");
        }
    }
}
