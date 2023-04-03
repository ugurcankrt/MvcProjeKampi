namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_about_aboutstatus_column_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abouts", "AbouStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AbouStatus");
        }
    }
}
