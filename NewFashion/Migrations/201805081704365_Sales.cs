namespace NewFashion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sales : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sales", "ProductId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sales", "ProductId");
            AddForeignKey("dbo.Sales", "ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "ProductId", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "ProductId" });
            AlterColumn("dbo.Sales", "ProductId", c => c.String());
        }
    }
}
