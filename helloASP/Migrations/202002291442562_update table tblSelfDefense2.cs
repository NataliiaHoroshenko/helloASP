namespace helloASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetabletblSelfDefense2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblSelfDefense", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblSelfDefense", "Image");
        }
    }
}
