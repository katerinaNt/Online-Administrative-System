namespace NewFashion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FactorySumSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cloth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Buttons = c.Int(nullable: false),
                        Stickers = c.Int(nullable: false),
                        Thread = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zipper = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FactorySumSupplies");
        }
    }
}
