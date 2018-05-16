namespace Mr_FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedticketmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketTickets", "Ticket_ID", "dbo.Tickets");
            DropForeignKey("dbo.TicketTickets", "Ticket_ID1", "dbo.Tickets");
            DropIndex("dbo.TicketTickets", new[] { "Ticket_ID" });
            DropIndex("dbo.TicketTickets", new[] { "Ticket_ID1" });
            AddColumn("dbo.Tickets", "NatureOfTicket", c => c.String());
            DropTable("dbo.TicketTickets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketTickets",
                c => new
                    {
                        Ticket_ID = c.Int(nullable: false),
                        Ticket_ID1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_ID, t.Ticket_ID1 });
            
            DropColumn("dbo.Tickets", "NatureOfTicket");
            CreateIndex("dbo.TicketTickets", "Ticket_ID1");
            CreateIndex("dbo.TicketTickets", "Ticket_ID");
            AddForeignKey("dbo.TicketTickets", "Ticket_ID1", "dbo.Tickets", "ID");
            AddForeignKey("dbo.TicketTickets", "Ticket_ID", "dbo.Tickets", "ID");
        }
    }
}
