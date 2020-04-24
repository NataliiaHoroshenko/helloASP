namespace helloASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtabletblSelfDefense : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblSelfDefense",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.tblDoges");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tblDoges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Breed = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 6),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.tblSelfDefense");
        }
    }
}
