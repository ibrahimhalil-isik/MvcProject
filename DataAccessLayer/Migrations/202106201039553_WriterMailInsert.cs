namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WriterMailInsert : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterMail", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterMail");
        }
    }
}
