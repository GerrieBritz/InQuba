namespace InQubaMail.Migrations
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
                        CreatedBy = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 100),
                        UpDatedDate = c.DateTime(nullable: false),
                        LocationId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                        LocationName = c.String(nullable: false),
                        StateId = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 100),
                        UpDatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emails", t => t.StateId)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "StateId", "dbo.Emails");
            DropForeignKey("dbo.Emails", "LocationId", "dbo.Locations");
            DropIndex("dbo.Locations", new[] { "StateId" });
            DropIndex("dbo.Emails", new[] { "LocationId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Emails");
        }
    }
}
