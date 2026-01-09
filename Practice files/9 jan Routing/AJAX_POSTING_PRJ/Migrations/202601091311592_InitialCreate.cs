namespace AJAX_POSTING_PRJ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        stuid = c.Int(nullable: false, identity: true),
                        studentname = c.String(nullable: false),
                        studnetAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.stuid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
