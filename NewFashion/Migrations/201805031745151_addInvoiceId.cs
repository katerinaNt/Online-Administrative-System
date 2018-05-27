namespace NewFashion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInvoiceId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "InvoiceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "InvoiceId");
        }
    }
}
