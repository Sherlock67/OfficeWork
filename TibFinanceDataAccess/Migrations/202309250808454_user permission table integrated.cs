namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userpermissiontableintegrated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        RoutingPath = c.String(),
                        ModuleName = c.String(),
                        MenuId = c.Int(nullable: false),
                        MenuName = c.String(),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        IsEdit = c.Boolean(nullable: false),
                        IsAdd = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsCreate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserPermissions");
        }
    }
}
