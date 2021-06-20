namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminUserNameUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminUserName", c => c.Binary());
        }
    }
}
