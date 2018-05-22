namespace Mr_FixIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtoticketmodelforemplyee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Tickets", "EmployeeId");
            AddForeignKey("dbo.Tickets", "EmployeeId", "dbo.Employees", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Tickets", new[] { "EmployeeId" });
            DropColumn("dbo.Tickets", "EmployeeId");
        }
    }
}
