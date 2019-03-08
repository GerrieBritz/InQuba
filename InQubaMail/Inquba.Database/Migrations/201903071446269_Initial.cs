namespace Inquba.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        From = c.String(nullable: false, maxLength: 200),
                        To = c.String(nullable: false, maxLength: 200),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Body = c.String(nullable: false),
                        ReadStatus = c.Boolean(nullable: false),
                        locationId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 100),
                        UpDatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.locationId)
                .Index(t => t.locationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        LocationName = c.String(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 100),
                        UpDatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "locationId", "dbo.Locations");
            DropIndex("dbo.Emails", new[] { "locationId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Emails");
        }
    }
}
