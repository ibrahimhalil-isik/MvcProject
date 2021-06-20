namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationwriter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "WriterMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterMail", c => c.Binary());
        }
    }
}
