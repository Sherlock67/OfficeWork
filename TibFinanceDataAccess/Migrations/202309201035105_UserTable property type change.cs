namespace TibFinanceDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTablepropertytypechange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserLogins", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLogins", "Password", c => c.Int(nullable: false));
        }
    }
}
