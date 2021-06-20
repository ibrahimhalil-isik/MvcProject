namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminRole");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminUserName");
        }
    }
}
