namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAddTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminUserName = c.Binary(),
                        AdminPasswordHash = c.Binary(),
                        AdminPasswordSalt = c.Binary(),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        TalentName = c.String(),
                        Range = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TalentId);
            
            AddColumn("dbo.Abouts", "AboutStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterPasswordHash", c => c.Binary());
            AddColumn("dbo.Writers", "WriterPasswordSalt", c => c.Binary());
            AddColumn("dbo.Messages", "Trash", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "Read", c => c.Boolean(nullable: false));
            DropColumn("dbo.Writers", "WriterPassword");
            DropColumn("dbo.Messages", "IsStar");
            DropColumn("dbo.Messages", "MessageStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsStar", c => c.Boolean(nullable: false));
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            DropColumn("dbo.Messages", "Read");
            DropColumn("dbo.Messages", "IsRead");
            DropColumn("dbo.Messages", "Trash");
            DropColumn("dbo.Writers", "WriterPasswordSalt");
            DropColumn("dbo.Writers", "WriterPasswordHash");
            DropColumn("dbo.Abouts", "AboutStatus");
            DropTable("dbo.Talents");
            DropTable("dbo.Admins");
        }
    }
}
