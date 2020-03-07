namespace helloASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtabletblPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        UrlSlug = c.String(nullable: false, maxLength: 50),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPosts", "CategoryId", "dbo.tblCategories");
            DropIndex("dbo.tblPosts", new[] { "CategoryId" });
            DropTable("dbo.tblPosts");
        }
    }
}
