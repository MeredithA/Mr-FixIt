namespace Mr_FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtoticketmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "UpdateNote", c => c.String());
            AddColumn("dbo.Tickets", "PostedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "CompletionDate", c => c.DateTime());
            AddColumn("dbo.Tickets", "TicketNotes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "TicketNotes");
            DropColumn("dbo.Tickets", "CompletionDate");
            DropColumn("dbo.Tickets", "UpdatedDate");
            DropColumn("dbo.Tickets", "PostedDate");
            DropColumn("dbo.Tickets", "UpdateNote");
        }
    }
}
