namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddAdminTemporary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminTemporaries",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminTemporaries");
        }
    }
}
