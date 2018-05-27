namespace NewFashion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Factory_FactoryID", "dbo.Factories");
            DropForeignKey("dbo.Workers", "FactoryID", "dbo.Factories");
            DropIndex("dbo.Products", new[] { "Factory_FactoryID" });
            DropIndex("dbo.Workers", new[] { "FactoryID" });
            DropColumn("dbo.Products", "Factory_FactoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Factory_FactoryID", c => c.Int());
            CreateIndex("dbo.Workers", "FactoryID");
            CreateIndex("dbo.Products", "Factory_FactoryID");
            AddForeignKey("dbo.Workers", "FactoryID", "dbo.Factories", "FactoryID");
            AddForeignKey("dbo.Products", "Factory_FactoryID", "dbo.Factories", "FactoryID");
        }
    }
}
