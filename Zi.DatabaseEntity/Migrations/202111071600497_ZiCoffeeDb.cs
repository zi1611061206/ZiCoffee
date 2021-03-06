namespace Zi.DatabaseEntity.Migrations
{
    using System.Data.Entity.Migrations;
    using Zi.Utilities.Enumerators;

    public partial class ZiCoffeeDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                {
                    AreaId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    ParentId = c.String(nullable: false, maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.AreaId);

            CreateTable(
                "dbo.Tables",
                c => new
                {
                    TableId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Status = c.Int(nullable: false, defaultValue: (int)TableStatus.Ready),
                    AreaId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.TableId)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);

            CreateTable(
                "dbo.Bills",
                c => new
                {
                    BillId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    Total = c.Single(nullable: false, defaultValue: 0),
                    Vat = c.Single(nullable: false, defaultValue: 0),
                    AfterVat = c.Single(nullable: false, defaultValue: 0),
                    RealPay = c.Single(nullable: false, defaultValue: 0),
                    Status = c.Int(nullable: false, defaultValue: (int)BillStatus.UnPay),
                    LastedModify = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    UserId = c.Guid(nullable: false),
                    TableId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.Tables", t => t.TableId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TableId);

            CreateTable(
                "dbo.BillDetails",
                c => new
                {
                    BillId = c.Guid(nullable: false),
                    ProductId = c.Guid(nullable: false),
                    Quantity = c.Int(nullable: false, defaultValue: 1),
                    PromotionValue = c.Single(nullable: false, defaultValue: 0),
                    IntoMoney = c.Single(nullable: false, defaultValue: 0),
                })
                .PrimaryKey(t => new { t.BillId, t.ProductId })
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.BillId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(),
                    Status = c.Int(nullable: false, defaultValue: (int)ProductStatus.Availabled),
                    Thumnail = c.Binary(nullable: false),
                    Price = c.Single(nullable: false, defaultValue: 0),
                    PromotionValue = c.Single(nullable: false, defaultValue: 0),
                    CategoryId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(),
                    Status = c.Int(nullable: false, defaultValue: (int)CategoryStatus.Availabled),
                    ParentId = c.String(nullable: false, maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.Recipes",
                c => new
                {
                    RecipeId = c.Guid(nullable: false),
                    ProductId = c.Guid(nullable: false),
                    Guide = c.String(),
                })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.RecipeDetails",
                c => new
                {
                    RecipeId = c.Guid(nullable: false),
                    MaterialId = c.Guid(nullable: false),
                    Quantitative = c.Single(nullable: false, defaultValue: 1),
                })
                .PrimaryKey(t => new { t.RecipeId, t.MaterialId })
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId)
                .Index(t => t.MaterialId);

            CreateTable(
                "dbo.Materials",
                c => new
                {
                    MaterialId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Unit = c.String(nullable: false, maxLength: 10),
                    Quantity = c.Int(nullable: false, defaultValue: 1),
                })
                .PrimaryKey(t => t.MaterialId);

            CreateTable(
                "dbo.ReceiptDetails",
                c => new
                {
                    ReceiptId = c.Guid(nullable: false),
                    MaterialId = c.Guid(nullable: false),
                    Quantity = c.Int(nullable: false, defaultValue: 1),
                    ImportPrice = c.Single(nullable: false, defaultValue: 0),
                })
                .PrimaryKey(t => new { t.ReceiptId, t.MaterialId })
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Receipts", t => t.ReceiptId, cascadeDelete: true)
                .Index(t => t.ReceiptId)
                .Index(t => t.MaterialId);

            CreateTable(
                "dbo.Receipts",
                c => new
                {
                    ReceiptId = c.Guid(nullable: false),
                    CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    SupplierId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.ReceiptId)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId);

            CreateTable(
                "dbo.Suppliers",
                c => new
                {
                    SupplierId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Address = c.String(maxLength: 100),
                    PhoneNumber = c.String(maxLength: 11, unicode: false),
                    Email = c.String(maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.SupplierId);

            CreateTable(
                "dbo.DiscountDetails",
                c => new
                {
                    BillId = c.Guid(nullable: false),
                    PromotionId = c.Guid(nullable: false),
                    Code = c.String(maxLength: 100, unicode: false),
                    AppliedTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                })
                .PrimaryKey(t => new { t.BillId, t.PromotionId })
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.PromotionId, cascadeDelete: true)
                .Index(t => t.BillId)
                .Index(t => t.PromotionId);

            CreateTable(
                "dbo.Promotions",
                c => new
                {
                    PromotionId = c.Guid(nullable: false),
                    Description = c.String(),
                    IsActived = c.Int(nullable: false, defaultValue: (int)PromotionActived.NotActivated),
                    IsAutoApply = c.Int(nullable: false, defaultValue: (int)PromotionAutoApply.Manual),
                    IsPercent = c.Int(nullable: false, defaultValue: (int)PromotionPercent.Normal),
                    Value = c.Single(nullable: false, defaultValue: 1),
                    StartTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    EndTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    MinValue = c.Single(nullable: false, defaultValue: 0),
                    CodeList = c.String(unicode: false),
                    PromotionTypeId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.PromotionId)
                .ForeignKey("dbo.PromotionTypes", t => t.PromotionTypeId, cascadeDelete: true)
                .Index(t => t.PromotionTypeId);

            CreateTable(
                "dbo.PromotionTypes",
                c => new
                {
                    PromotionTypeId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.PromotionTypeId);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    UserId = c.Guid(nullable: false),
                    FirstName = c.String(nullable: false, maxLength: 10),
                    MiddleName = c.String(maxLength: 30),
                    LastName = c.String(nullable: false, maxLength: 10),
                    Username = c.String(nullable: false, maxLength: 10, unicode: false),
                    DisplayName = c.String(nullable: false, maxLength: 50),
                    PhoneNumber = c.String(nullable: false, maxLength: 11, unicode: false),
                    Email = c.String(nullable: false, maxLength: 50, unicode: false),
                    DateOfBirth = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    PasswordHash = c.String(maxLength: 100, unicode: false),
                    Gender = c.Int(nullable: false, defaultValue: (int)Genders.Male),
                    Avatar = c.Binary(),
                    CitizenId = c.String(maxLength: 15, unicode: false),
                    Address = c.String(nullable: false, maxLength: 100),
                    Salt = c.String(maxLength: 50, unicode: false),
                })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.Logs",
                c => new
                {
                    LogId = c.Guid(nullable: false),
                    UserId = c.Guid(nullable: false),
                    EventId = c.Guid(nullable: false),
                    Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2", defaultValueSql: "GetDate()"),
                    Content = c.String(),
                })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.EventId);

            CreateTable(
                "dbo.Events",
                c => new
                {
                    EventId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.EventId);

            CreateTable(
                "dbo.UserRole",
                c => new
                {
                    UserId = c.Guid(nullable: false),
                    RoleId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    RoleId = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    Description = c.String(),
                    AccessLevel = c.Int(nullable: false, defaultValue: (int)AccessLevels.Manager),
                })
                .PrimaryKey(t => t.RoleId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Bills", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Logs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Logs", "EventId", "dbo.Events");
            DropForeignKey("dbo.Bills", "TableId", "dbo.Tables");
            DropForeignKey("dbo.DiscountDetails", "PromotionId", "dbo.Promotions");
            DropForeignKey("dbo.Promotions", "PromotionTypeId", "dbo.PromotionTypes");
            DropForeignKey("dbo.DiscountDetails", "BillId", "dbo.Bills");
            DropForeignKey("dbo.BillDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.RecipeDetails", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeDetails", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.ReceiptDetails", "ReceiptId", "dbo.Receipts");
            DropForeignKey("dbo.Receipts", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ReceiptDetails", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Recipes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BillDetails", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Tables", "AreaId", "dbo.Areas");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Logs", new[] { "EventId" });
            DropIndex("dbo.Logs", new[] { "UserId" });
            DropIndex("dbo.Promotions", new[] { "PromotionTypeId" });
            DropIndex("dbo.DiscountDetails", new[] { "PromotionId" });
            DropIndex("dbo.DiscountDetails", new[] { "BillId" });
            DropIndex("dbo.Receipts", new[] { "SupplierId" });
            DropIndex("dbo.ReceiptDetails", new[] { "MaterialId" });
            DropIndex("dbo.ReceiptDetails", new[] { "ReceiptId" });
            DropIndex("dbo.RecipeDetails", new[] { "MaterialId" });
            DropIndex("dbo.RecipeDetails", new[] { "RecipeId" });
            DropIndex("dbo.Recipes", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.BillDetails", new[] { "ProductId" });
            DropIndex("dbo.BillDetails", new[] { "BillId" });
            DropIndex("dbo.Bills", new[] { "TableId" });
            DropIndex("dbo.Bills", new[] { "UserId" });
            DropIndex("dbo.Tables", new[] { "AreaId" });
            DropTable("dbo.Roles");
            DropTable("dbo.UserRole");
            DropTable("dbo.Events");
            DropTable("dbo.Logs");
            DropTable("dbo.Users");
            DropTable("dbo.PromotionTypes");
            DropTable("dbo.Promotions");
            DropTable("dbo.DiscountDetails");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Receipts");
            DropTable("dbo.ReceiptDetails");
            DropTable("dbo.Materials");
            DropTable("dbo.RecipeDetails");
            DropTable("dbo.Recipes");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.BillDetails");
            DropTable("dbo.Bills");
            DropTable("dbo.Tables");
            DropTable("dbo.Areas");
        }
    }
}
