namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WriterEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterEmail", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "WriterMail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            DropColumn("dbo.Writers", "WriterEmail");
        }
    }
}
