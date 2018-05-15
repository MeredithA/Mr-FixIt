namespace Mr_FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tickets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketXTenants", "TenantId", "dbo.Tenants");
            DropIndex("dbo.TicketXTenants", new[] { "TenantId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.TicketXTenants", "TenantId");
            AddForeignKey("dbo.TicketXTenants", "TenantId", "dbo.Tenants", "ID", cascadeDelete: true);
        }
    }
}
