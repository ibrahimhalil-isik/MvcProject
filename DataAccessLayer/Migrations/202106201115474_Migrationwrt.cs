namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrationwrt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterMail");
        }
    }
}
