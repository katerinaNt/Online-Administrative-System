namespace NewFashion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingType = c.Int(nullable: false),
                        City = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BuildingId);
            
            CreateTable(
                "dbo.Buyings",
                c => new
                    {
                        SaleId = c.Int(nullable: false),
                        ProductId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SaleId, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.SaleId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.String(nullable: false, maxLength: 128),
                        Type = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WarehouseQuantity = c.Int(nullable: false),
                        StoreQuantity = c.Int(nullable: false),
                        Factory_FactoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Factories", t => t.Factory_FactoryID)
                .Index(t => t.Factory_FactoryID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        ProductId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Factories",
                c => new
                    {
                        FactoryID = c.Int(nullable: false, identity: true),
                        ClothesDailyProdutionLog = c.String(),
                        TrousersDailyProdutionLog = c.String(),
                    })
                .PrimaryKey(t => t.FactoryID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        WorkerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FactoryID = c.Int(),
                        WarehouseID = c.Int(),
                    })
                .PrimaryKey(t => t.WorkerID)
                .ForeignKey("dbo.Factories", t => t.FactoryID)
                .Index(t => t.FactoryID);
            
            CreateTable(
                "dbo.Offices",
                c => new
                    {
                        OfficeID = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.OfficeID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        ProductCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID);
            
            CreateTable(
                "dbo.SupplierOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cloth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PricePerMeter = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Buttons = c.Int(nullable: false),
                        PricePerButton = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stickers = c.Int(nullable: false),
                        PricePerSticker = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Thread = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PricePerThread = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zipper = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PricePerZipper = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsSelected = c.Boolean(nullable: false),
                        SupplierID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Lastname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierOffers", "SupplierID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Workers", "FactoryID", "dbo.Factories");
            DropForeignKey("dbo.Products", "Factory_FactoryID", "dbo.Factories");
            DropForeignKey("dbo.Buyings", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.Buyings", "ProductId", "dbo.Products");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SupplierOffers", new[] { "SupplierID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Workers", new[] { "FactoryID" });
            DropIndex("dbo.Products", new[] { "Factory_FactoryID" });
            DropIndex("dbo.Buyings", new[] { "ProductId" });
            DropIndex("dbo.Buyings", new[] { "SaleId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SupplierOffers");
            DropTable("dbo.Stores");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Offices");
            DropTable("dbo.Workers");
            DropTable("dbo.Factories");
            DropTable("dbo.Sales");
            DropTable("dbo.Products");
            DropTable("dbo.Buyings");
            DropTable("dbo.Buildings");
        }
    }
}
