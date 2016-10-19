namespace SimpleShopWebFr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Passwd = c.String(unicode: false),
                        QQ = c.String(unicode: false),
                        TelPhone = c.String(unicode: false),
                        CellPhone = c.String(unicode: false),
                        Sex = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Flag = c.Boolean(nullable: false),
                        Amount = c.Int(nullable: false),
                        BillDescription = c.String(unicode: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Passwd = c.String(unicode: false),
                        QQ = c.String(unicode: false),
                        TelPhone = c.String(unicode: false),
                        CellPhone = c.String(unicode: false),
                        Sex = c.Boolean(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        ParentId = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FinancialAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Int(nullable: false),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Member_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(unicode: false),
                        UnitPrice = c.Int(nullable: false),
                        ProductDescription = c.String(unicode: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Category_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(unicode: false),
                        SortNum = c.Int(nullable: false),
                        ThumbPhotoUrl = c.String(unicode: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ShipAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceivePerson = c.String(unicode: false),
                        CellPhone = c.String(unicode: false),
                        LastAddress = c.String(unicode: false),
                        OtherDesc = c.String(unicode: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Member_Id = c.Int(),
                        StandardAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id)
                .ForeignKey("dbo.StandardAddresses", t => t.StandardAddress_Id)
                .Index(t => t.Member_Id)
                .Index(t => t.StandardAddress_Id);
            
            CreateTable(
                "dbo.StandardAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(unicode: false),
                        CityName = c.String(unicode: false),
                        AreaName = c.String(unicode: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipAddresses", "StandardAddress_Id", "dbo.StandardAddresses");
            DropForeignKey("dbo.ShipAddresses", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Photos", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Orders", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.FinancialAccounts", "Member_Id", "dbo.Members");
            DropForeignKey("dbo.BillDetails", "Member_Id", "dbo.Members");
            DropIndex("dbo.ShipAddresses", new[] { "StandardAddress_Id" });
            DropIndex("dbo.ShipAddresses", new[] { "Member_Id" });
            DropIndex("dbo.Photos", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Orders", new[] { "Member_Id" });
            DropIndex("dbo.FinancialAccounts", new[] { "Member_Id" });
            DropIndex("dbo.BillDetails", new[] { "Member_Id" });
            DropTable("dbo.StandardAddresses");
            DropTable("dbo.ShipAddresses");
            DropTable("dbo.Photos");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.FinancialAccounts");
            DropTable("dbo.Categories");
            DropTable("dbo.Members");
            DropTable("dbo.BillDetails");
            DropTable("dbo.Admins");
        }
    }
}
