namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpermissiontablechangedavariable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPermissions", "isGetAll", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserPermissions", "IsAdd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserPermissions", "IsAdd", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserPermissions", "isGetAll");
        }
    }
}
