namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        CourseDescription = c.String(),
                        CourseTitle = c.String(),
                        CourseCode = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginID);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        PermissionId = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(),
                        RoutingPath = c.String(),
                        MenuId = c.Int(),
                        UserId = c.Int(),
                        RoleId = c.Int(),
                        IsEdit = c.Boolean(nullable: false),
                        isGetAll = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        IsCreate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PermissionId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuName = c.String(),
                        MenuDescription = c.String(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        CreatedBy = c.String(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FullName = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Modules");
            DropTable("dbo.Menus");
            DropTable("dbo.UserPermissions");
            DropTable("dbo.UserLogins");
            DropTable("dbo.Customers");
            DropTable("dbo.Courses");
        }
    }
}
