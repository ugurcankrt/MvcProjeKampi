﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writerimage_column_edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
        }
    }
}
