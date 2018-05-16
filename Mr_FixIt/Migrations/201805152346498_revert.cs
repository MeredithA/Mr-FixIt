namespace Mr_FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Tenant_ID", "dbo.Tenants");
            DropIndex("dbo.Tickets", new[] { "Tenant_ID" });
            DropColumn("dbo.Tickets", "TicketList_DataGroupField");
            DropColumn("dbo.Tickets", "TicketList_DataTextField");
            DropColumn("dbo.Tickets", "TicketList_DataValueField");
            DropColumn("dbo.Tickets", "Tenant_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Tenant_ID", c => c.Int());
            AddColumn("dbo.Tickets", "TicketList_DataValueField", c => c.String());
            AddColumn("dbo.Tickets", "TicketList_DataTextField", c => c.String());
            AddColumn("dbo.Tickets", "TicketList_DataGroupField", c => c.String());
            CreateIndex("dbo.Tickets", "Tenant_ID");
            AddForeignKey("dbo.Tickets", "Tenant_ID", "dbo.Tenants", "ID");
        }
    }
}
