namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAdmin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "AdminUserName");
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 20));
        }
    }
}
