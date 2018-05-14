namespace Mr_FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingXManagers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BuildId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        building_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Buildings", t => t.building_ID)
                .Index(t => t.building_ID);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BulletinBoards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        BuildingId = c.Int(nullable: false),
                        Message = c.String(),
                        DateEdited = c.String(),
                        DatePosted = c.String(),
                        OwnerId = c.String(maxLength: 128),
                        VisableToTenants = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.BuildingId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAdrress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        EmailAdrress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        BuildingId = c.Int(nullable: false),
                        ApartmentNumber = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        EmailAdrress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LocationOfTheReuqest = c.String(),
                        ReceiveUpdate = c.Boolean(nullable: false),
                        AdditionalInformation = c.String(),
                        FilePath = c.String(),
                        FileName = c.String(),
                        Ticket_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID)
                .Index(t => t.Ticket_ID);
            
            CreateTable(
                "dbo.TicketXTenants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketXTenants", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketXTenants", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.Tickets", "Ticket_ID", "dbo.Tickets");
            DropForeignKey("dbo.Tenants", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tenants", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Managers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BulletinBoards", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BulletinBoards", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.BuildingXManagers", "building_ID", "dbo.Buildings");
            DropIndex("dbo.TicketXTenants", new[] { "TenantId" });
            DropIndex("dbo.TicketXTenants", new[] { "TicketId" });
            DropIndex("dbo.Tickets", new[] { "Ticket_ID" });
            DropIndex("dbo.Tenants", new[] { "BuildingId" });
            DropIndex("dbo.Tenants", new[] { "UserId" });
            DropIndex("dbo.Managers", new[] { "UserId" });
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.BulletinBoards", new[] { "OwnerId" });
            DropIndex("dbo.BulletinBoards", new[] { "BuildingId" });
            DropIndex("dbo.BuildingXManagers", new[] { "building_ID" });
            DropTable("dbo.TicketXTenants");
            DropTable("dbo.Tickets");
            DropTable("dbo.Tenants");
            DropTable("dbo.Managers");
            DropTable("dbo.Employees");
            DropTable("dbo.BulletinBoards");
            DropTable("dbo.Buildings");
            DropTable("dbo.BuildingXManagers");
        }
    }
}
