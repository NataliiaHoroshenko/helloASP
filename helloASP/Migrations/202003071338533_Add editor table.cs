namespace helloASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeditortable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblEditors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Otcher = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.tblEditors");
        }
    }
}
