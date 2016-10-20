namespace SimpleShopWebFr.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Passwd = c.String(nullable: false, unicode: false),
                        Salt = c.String(nullable: false, unicode: false),
                        QQ = c.String(unicode: false),
                        TelPhone = c.String(unicode: false),
                        CellPhone = c.String(nullable: false, unicode: false),
                        Sex = c.Int(nullable: false),
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
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Passwd = c.String(nullable: false, unicode: false),
                        Salt = c.String(nullable: false, unicode: false),
                        QQ = c.String(unicode: false),
                        TelPhone = c.String(unicode: false),
                        CellPhone = c.String(nullable: false, unicode: false),
                        Sex = c.Int(nullable: false),
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
                        CategoryName = c.String(nullable: false, unicode: false),
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
                        AlipayAccount = c.String(unicode: false),
                        WechatPayAccount = c.String(unicode: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Member_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, unicode: false),
                        UnitPrice = c.Int(nullable: false),
                        ProductDescription = c.String(unicode: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Category_Id = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(nullable: false, unicode: false),
                        SortNum = c.Int(nullable: false),
                        ThumbPhotoUrl = c.String(nullable: false, unicode: false),
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
                        ReceivePerson = c.String(nullable: false, unicode: false),
                        CellPhone = c.String(nullable: false, unicode: false),
                        LastAddress = c.String(nullable: false, unicode: false),
                        OtherDesc = c.String(unicode: false),
                        CreateDateTime = c.DateTime(nullable: false, precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteDateTime = c.DateTime(nullable: false, precision: 0),
                        Member_Id = c.Int(nullable: false),
                        StandardAddress_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.Member_Id, cascadeDelete: true)
                .ForeignKey("dbo.StandardAddresses", t => t.StandardAddress_Id, cascadeDelete: true)
                .Index(t => t.Member_Id)
                .Index(t => t.StandardAddress_Id);
            
            CreateTable(
                "dbo.StandardAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false, unicode: false),
                        CityName = c.String(nullable: false, unicode: false),
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
