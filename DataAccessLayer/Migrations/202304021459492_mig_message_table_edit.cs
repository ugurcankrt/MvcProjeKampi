namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_message_table_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "IsOpened", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "IsOpened");
        }
    }
}
