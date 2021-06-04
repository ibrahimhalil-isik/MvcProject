namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageFileClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsDraft", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "IsStar", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatus");
            DropColumn("dbo.Messages", "IsStar");
            DropColumn("dbo.Messages", "IsDraft");
        }
    }
}
