namespace helloASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeditortableupdatesize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblEditors", "Otcher", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblEditors", "Otcher", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
