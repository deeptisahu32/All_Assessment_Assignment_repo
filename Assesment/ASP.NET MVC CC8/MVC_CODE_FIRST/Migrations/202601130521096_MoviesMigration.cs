namespace MVC_CODE_FIRST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Mid = c.Int(nullable: false, identity: true),
                        MovieName = c.String(nullable: false, maxLength: 200),
                        DirectorName = c.String(nullable: false, maxLength: 200),
                        DateOfRelease = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Mid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
