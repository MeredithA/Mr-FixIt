namespace Mr_FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Ticket_ID", "dbo.Tickets");
            DropIndex("dbo.Tickets", new[] { "Ticket_ID" });
            CreateTable(
                "dbo.TicketTickets",
                c => new
                    {
                        Ticket_ID = c.Int(nullable: false),
                        Ticket_ID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_ID, t.Ticket_ID1 })
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID)
                .ForeignKey("dbo.Tickets", t => t.Ticket_ID1)
                .Index(t => t.Ticket_ID)
                .Index(t => t.Ticket_ID1);
            
            DropColumn("dbo.Tickets", "NatureOfTicket");
            DropColumn("dbo.Tickets", "Ticket_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Ticket_ID", c => c.Int());
            AddColumn("dbo.Tickets", "NatureOfTicket", c => c.String());
            DropForeignKey("dbo.TicketTickets", "Ticket_ID1", "dbo.Tickets");
            DropForeignKey("dbo.TicketTickets", "Ticket_ID", "dbo.Tickets");
            DropIndex("dbo.TicketTickets", new[] { "Ticket_ID1" });
            DropIndex("dbo.TicketTickets", new[] { "Ticket_ID" });
            DropTable("dbo.TicketTickets");
            CreateIndex("dbo.Tickets", "Ticket_ID");
            AddForeignKey("dbo.Tickets", "Ticket_ID", "dbo.Tickets", "ID");
        }
    }
}
