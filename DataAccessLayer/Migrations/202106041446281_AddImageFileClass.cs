namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageFileClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 50),
                        ImagePath = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ImageId);
            
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsStar", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
            DropColumn("dbo.Messages", "IsStar");
            DropColumn("dbo.Messages", "IsDraft");
            DropTable("dbo.ImageFiles");
        }
    }
}
