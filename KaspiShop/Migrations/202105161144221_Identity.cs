namespace KaspiShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessEntityID = c.Int(nullable: false),
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
                .ForeignKey("Person.Person", t => t.BusinessEntityID, cascadeDelete: true)
                .Index(t => t.BusinessEntityID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
         
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.PersonPhone", "PhoneNumberTypeID", "Person.PhoneNumberType");
            DropForeignKey("Person.PersonPhone", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.Password", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.EmailAddress", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.Person", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.BusinessEntityContact", "BusinessEntityID", "Person.Person");
            DropForeignKey("Person.BusinessEntityContact", "ContactTypeID", "Person.ContactType");
            DropForeignKey("Person.BusinessEntityContact", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.BusinessEntityAddress", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Person.BusinessEntityAddress", "AddressTypeID", "Person.AddressType");
            DropForeignKey("Sales.SalesOrderHeader", "Address_AddressID2", "Person.Address");
            DropForeignKey("Sales.SalesOrderHeader", "Address_AddressID1", "Person.Address");
            DropForeignKey("Sales.SalesOrderHeaderSalesReason", "SalesReasonID", "Sales.SalesReason");
            DropForeignKey("Sales.SalesOrderHeaderSalesReason", "SalesOrderID", "Sales.SalesOrderHeader");
            DropForeignKey("Sales.SalesOrderHeader", "CurrencyRateID", "Sales.CurrencyRate");
            DropForeignKey("Sales.CurrencyRate", "Currency1_CurrencyCode", "Sales.Currency");
            DropForeignKey("Sales.CurrencyRate", "Currency_CurrencyCode2", "Sales.Currency");
            DropForeignKey("Sales.CurrencyRate", "Currency_CurrencyCode1", "Sales.Currency");
            DropForeignKey("Sales.CurrencyRate", "Currency_CurrencyCode", "Sales.Currency");
            DropForeignKey("Sales.CountryRegionCurrency", "CurrencyCode", "Sales.Currency");
            DropForeignKey("Person.StateProvince", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.SalesTaxRate", "StateProvinceID", "Person.StateProvince");
            DropForeignKey("Person.StateProvince", "CountryRegionCode", "Person.CountryRegion");
            DropForeignKey("Person.Address", "StateProvinceID", "Person.StateProvince");
            DropForeignKey("Sales.SalesOrderHeader", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.Store", "SalesPerson_BusinessEntityID", "Sales.SalesPerson");
            DropForeignKey("Sales.SalesTerritoryHistory", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.SalesTerritoryHistory", "BusinessEntityID", "Sales.SalesPerson");
            DropForeignKey("Sales.SalesPerson", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.SalesPersonQuotaHistory", "BusinessEntityID", "Sales.SalesPerson");
            DropForeignKey("Sales.SalesOrderHeader", "SalesPerson_BusinessEntityID", "Sales.SalesPerson");
            DropForeignKey("Sales.SalesPerson", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("Sales.SalesOrderHeader", "ShipMethodID", "Purchasing.ShipMethod");
            DropForeignKey("Purchasing.PurchaseOrderHeader", "ShipMethodID", "Purchasing.ShipMethod");
            DropForeignKey("Purchasing.PurchaseOrderDetail", "PurchaseOrderID", "Purchasing.PurchaseOrderHeader");
            DropForeignKey("Production.Product", "UnitMeasure1_UnitMeasureCode", "Production.UnitMeasure");
            DropForeignKey("Production.Product", "UnitMeasure_UnitMeasureCode2", "Production.UnitMeasure");
            DropForeignKey("Production.TransactionHistory", "ProductID", "Production.Product");
            DropForeignKey("Sales.SpecialOfferProduct", "SpecialOfferID", "Sales.SpecialOffer");
            DropForeignKey("Sales.SalesOrderDetail", new[] { "SpecialOfferID", "ProductID" }, "Sales.SpecialOfferProduct");
            DropForeignKey("Sales.SalesOrderDetail", "SalesOrderID", "Sales.SalesOrderHeader");
            DropForeignKey("Sales.SpecialOfferProduct", "ProductID", "Production.Product");
            DropForeignKey("Sales.ShoppingCartItem", "ProductID", "Production.Product");
            DropForeignKey("Purchasing.PurchaseOrderDetail", "ProductID", "Production.Product");
            DropForeignKey("Production.Product", "ProductSubcategoryID", "Production.ProductSubcategory");
            DropForeignKey("Production.ProductSubcategory", "ProductCategoryID", "Production.ProductCategory");
            DropForeignKey("Production.ProductReview", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductProductPhoto", "ProductPhotoID", "Production.ProductPhoto");
            DropForeignKey("Production.ProductProductPhoto", "ProductID", "Production.Product");
            DropForeignKey("Production.Product", "ProductModelID", "Production.ProductModel");
            DropForeignKey("Production.ProductModelProductDescriptionCulture", "ProductModelID", "Production.ProductModel");
            DropForeignKey("Production.ProductModelProductDescriptionCulture", "ProductDescriptionID", "Production.ProductDescription");
            DropForeignKey("Production.ProductModelProductDescriptionCulture", "CultureID", "Production.Culture");
            DropForeignKey("Production.ProductModelIllustration", "ProductModelID", "Production.ProductModel");
            DropForeignKey("Production.ProductModelIllustration", "IllustrationID", "Production.Illustration");
            DropForeignKey("Production.ProductListPriceHistory", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductInventory", "ProductID", "Production.Product");
            DropForeignKey("Production.WorkOrderRouting", "WorkOrderID", "Production.WorkOrder");
            DropForeignKey("Production.WorkOrder", "ScrapReasonID", "Production.ScrapReason");
            DropForeignKey("Production.WorkOrder", "ProductID", "Production.Product");
            DropForeignKey("Production.WorkOrderRouting", "LocationID", "Production.Location");
            DropForeignKey("Production.ProductInventory", "LocationID", "Production.Location");
            DropForeignKey("Production.ProductDocument", "ProductID", "Production.Product");
            DropForeignKey("Production.ProductCostHistory", "ProductID", "Production.Product");
            DropForeignKey("Production.BillOfMaterials", "Product_ProductID2", "Production.Product");
            DropForeignKey("Production.BillOfMaterials", "Product_ProductID1", "Production.Product");
            DropForeignKey("Purchasing.PurchaseOrderHeader", "Vendor_BusinessEntityID", "Purchasing.Vendor");
            DropForeignKey("Purchasing.ProductVendor", "BusinessEntityID", "Purchasing.Vendor");
            DropForeignKey("Purchasing.Vendor", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Purchasing.ProductVendor", "UnitMeasureCode", "Production.UnitMeasure");
            DropForeignKey("Purchasing.ProductVendor", "ProductID", "Production.Product");
            DropForeignKey("Production.Product", "UnitMeasure_UnitMeasureCode1", "Production.UnitMeasure");
            DropForeignKey("Production.Product", "UnitMeasure_UnitMeasureCode", "Production.UnitMeasure");
            DropForeignKey("Production.BillOfMaterials", "UnitMeasureCode", "Production.UnitMeasure");
            DropForeignKey("Production.BillOfMaterials", "Product1_ProductID", "Production.Product");
            DropForeignKey("Production.BillOfMaterials", "Product_ProductID", "Production.Product");
            DropForeignKey("Purchasing.PurchaseOrderHeader", "Employee_BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("HumanResources.Employee", "BusinessEntityID", "Person.Person");
            DropForeignKey("HumanResources.JobCandidate", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("HumanResources.EmployeePayHistory", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("HumanResources.EmployeeDepartmentHistory", "ShiftID", "HumanResources.Shift");
            DropForeignKey("HumanResources.EmployeeDepartmentHistory", "BusinessEntityID", "HumanResources.Employee");
            DropForeignKey("HumanResources.EmployeeDepartmentHistory", "DepartmentID", "HumanResources.Department");
            DropForeignKey("Sales.Customer", "Store_BusinessEntityID", "Sales.Store");
            DropForeignKey("Sales.Store", "BusinessEntityID", "Person.BusinessEntity");
            DropForeignKey("Sales.Customer", "TerritoryID", "Sales.SalesTerritory");
            DropForeignKey("Sales.SalesOrderHeader", "CustomerID", "Sales.Customer");
            DropForeignKey("Sales.Customer", "Person_BusinessEntityID", "Person.Person");
            DropForeignKey("Sales.SalesTerritory", "CountryRegionCode", "Person.CountryRegion");
            DropForeignKey("Sales.CountryRegionCurrency", "CountryRegionCode", "Person.CountryRegion");
            DropForeignKey("Sales.SalesOrderHeader", "CreditCardID", "Sales.CreditCard");
            DropForeignKey("Sales.PersonCreditCard", "BusinessEntityID", "Person.Person");
            DropForeignKey("Sales.PersonCreditCard", "CreditCardID", "Sales.CreditCard");
            DropForeignKey("Sales.SalesOrderHeader", "Address1_AddressID", "Person.Address");
            DropForeignKey("Sales.SalesOrderHeader", "Address_AddressID", "Person.Address");
            DropForeignKey("Person.BusinessEntityAddress", "AddressID", "Person.Address");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("Person.PersonPhone", new[] { "PhoneNumberTypeID" });
            DropIndex("Person.PersonPhone", new[] { "BusinessEntityID" });
            DropIndex("Person.Password", new[] { "BusinessEntityID" });
            DropIndex("Person.EmailAddress", new[] { "BusinessEntityID" });
            DropIndex("Person.BusinessEntityContact", new[] { "ContactTypeID" });
            DropIndex("Person.BusinessEntityContact", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesOrderHeaderSalesReason", new[] { "SalesReasonID" });
            DropIndex("Sales.SalesOrderHeaderSalesReason", new[] { "SalesOrderID" });
            DropIndex("Sales.SalesTaxRate", new[] { "StateProvinceID" });
            DropIndex("Person.StateProvince", new[] { "TerritoryID" });
            DropIndex("Person.StateProvince", new[] { "CountryRegionCode" });
            DropIndex("Sales.SalesTerritoryHistory", new[] { "TerritoryID" });
            DropIndex("Sales.SalesTerritoryHistory", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesPersonQuotaHistory", new[] { "BusinessEntityID" });
            DropIndex("Production.TransactionHistory", new[] { "ProductID" });
            DropIndex("Sales.SalesOrderDetail", new[] { "SpecialOfferID", "ProductID" });
            DropIndex("Sales.SalesOrderDetail", new[] { "SalesOrderID" });
            DropIndex("Sales.SpecialOfferProduct", new[] { "ProductID" });
            DropIndex("Sales.SpecialOfferProduct", new[] { "SpecialOfferID" });
            DropIndex("Sales.ShoppingCartItem", new[] { "ProductID" });
            DropIndex("Production.ProductSubcategory", new[] { "ProductCategoryID" });
            DropIndex("Production.ProductReview", new[] { "ProductID" });
            DropIndex("Production.ProductProductPhoto", new[] { "ProductPhotoID" });
            DropIndex("Production.ProductProductPhoto", new[] { "ProductID" });
            DropIndex("Production.ProductModelProductDescriptionCulture", new[] { "CultureID" });
            DropIndex("Production.ProductModelProductDescriptionCulture", new[] { "ProductDescriptionID" });
            DropIndex("Production.ProductModelProductDescriptionCulture", new[] { "ProductModelID" });
            DropIndex("Production.ProductModelIllustration", new[] { "IllustrationID" });
            DropIndex("Production.ProductModelIllustration", new[] { "ProductModelID" });
            DropIndex("Production.ProductListPriceHistory", new[] { "ProductID" });
            DropIndex("Production.WorkOrder", new[] { "ScrapReasonID" });
            DropIndex("Production.WorkOrder", new[] { "ProductID" });
            DropIndex("Production.WorkOrderRouting", new[] { "LocationID" });
            DropIndex("Production.WorkOrderRouting", new[] { "WorkOrderID" });
            DropIndex("Production.ProductInventory", new[] { "LocationID" });
            DropIndex("Production.ProductInventory", new[] { "ProductID" });
            DropIndex("Production.ProductDocument", new[] { "ProductID" });
            DropIndex("Production.ProductCostHistory", new[] { "ProductID" });
            DropIndex("Purchasing.Vendor", new[] { "BusinessEntityID" });
            DropIndex("Purchasing.ProductVendor", new[] { "UnitMeasureCode" });
            DropIndex("Purchasing.ProductVendor", new[] { "BusinessEntityID" });
            DropIndex("Purchasing.ProductVendor", new[] { "ProductID" });
            DropIndex("Production.BillOfMaterials", new[] { "Product_ProductID2" });
            DropIndex("Production.BillOfMaterials", new[] { "Product_ProductID1" });
            DropIndex("Production.BillOfMaterials", new[] { "Product1_ProductID" });
            DropIndex("Production.BillOfMaterials", new[] { "Product_ProductID" });
            DropIndex("Production.BillOfMaterials", new[] { "UnitMeasureCode" });
            DropIndex("Production.Product", new[] { "UnitMeasure1_UnitMeasureCode" });
            DropIndex("Production.Product", new[] { "UnitMeasure_UnitMeasureCode2" });
            DropIndex("Production.Product", new[] { "UnitMeasure_UnitMeasureCode1" });
            DropIndex("Production.Product", new[] { "UnitMeasure_UnitMeasureCode" });
            DropIndex("Production.Product", new[] { "ProductModelID" });
            DropIndex("Production.Product", new[] { "ProductSubcategoryID" });
            DropIndex("Purchasing.PurchaseOrderDetail", new[] { "ProductID" });
            DropIndex("Purchasing.PurchaseOrderDetail", new[] { "PurchaseOrderID" });
            DropIndex("Purchasing.PurchaseOrderHeader", new[] { "Vendor_BusinessEntityID" });
            DropIndex("Purchasing.PurchaseOrderHeader", new[] { "Employee_BusinessEntityID" });
            DropIndex("Purchasing.PurchaseOrderHeader", new[] { "ShipMethodID" });
            DropIndex("HumanResources.JobCandidate", new[] { "BusinessEntityID" });
            DropIndex("HumanResources.EmployeePayHistory", new[] { "BusinessEntityID" });
            DropIndex("HumanResources.EmployeeDepartmentHistory", new[] { "ShiftID" });
            DropIndex("HumanResources.EmployeeDepartmentHistory", new[] { "DepartmentID" });
            DropIndex("HumanResources.EmployeeDepartmentHistory", new[] { "BusinessEntityID" });
            DropIndex("HumanResources.Employee", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesPerson", new[] { "TerritoryID" });
            DropIndex("Sales.SalesPerson", new[] { "BusinessEntityID" });
            DropIndex("Sales.Store", new[] { "SalesPerson_BusinessEntityID" });
            DropIndex("Sales.Store", new[] { "BusinessEntityID" });
            DropIndex("Sales.Customer", new[] { "Store_BusinessEntityID" });
            DropIndex("Sales.Customer", new[] { "Person_BusinessEntityID" });
            DropIndex("Sales.Customer", new[] { "TerritoryID" });
            DropIndex("Sales.SalesTerritory", new[] { "CountryRegionCode" });
            DropIndex("Sales.CountryRegionCurrency", new[] { "CurrencyCode" });
            DropIndex("Sales.CountryRegionCurrency", new[] { "CountryRegionCode" });
            DropIndex("Sales.CurrencyRate", new[] { "Currency1_CurrencyCode" });
            DropIndex("Sales.CurrencyRate", new[] { "Currency_CurrencyCode2" });
            DropIndex("Sales.CurrencyRate", new[] { "Currency_CurrencyCode1" });
            DropIndex("Sales.CurrencyRate", new[] { "Currency_CurrencyCode" });
            DropIndex("Sales.PersonCreditCard", new[] { "CreditCardID" });
            DropIndex("Sales.PersonCreditCard", new[] { "BusinessEntityID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "Address_AddressID2" });
            DropIndex("Sales.SalesOrderHeader", new[] { "Address_AddressID1" });
            DropIndex("Sales.SalesOrderHeader", new[] { "SalesPerson_BusinessEntityID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "Address1_AddressID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "Address_AddressID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "CurrencyRateID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "CreditCardID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "ShipMethodID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "TerritoryID" });
            DropIndex("Sales.SalesOrderHeader", new[] { "CustomerID" });
            DropIndex("Person.Address", new[] { "StateProvinceID" });
            DropIndex("Person.BusinessEntityAddress", new[] { "AddressTypeID" });
            DropIndex("Person.BusinessEntityAddress", new[] { "AddressID" });
            DropIndex("Person.BusinessEntityAddress", new[] { "BusinessEntityID" });
            DropIndex("Person.Person", new[] { "BusinessEntityID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "BusinessEntityID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("Person.PhoneNumberType");
            DropTable("Person.PersonPhone");
            DropTable("Person.Password");
            DropTable("Person.EmailAddress");
            DropTable("Person.ContactType");
            DropTable("Person.BusinessEntityContact");
            DropTable("Person.AddressType");
            DropTable("Sales.SalesReason");
            DropTable("Sales.SalesOrderHeaderSalesReason");
            DropTable("Sales.SalesTaxRate");
            DropTable("Person.StateProvince");
            DropTable("Sales.SalesTerritoryHistory");
            DropTable("Sales.SalesPersonQuotaHistory");
            DropTable("Purchasing.ShipMethod");
            DropTable("Production.TransactionHistory");
            DropTable("Sales.SpecialOffer");
            DropTable("Sales.SalesOrderDetail");
            DropTable("Sales.SpecialOfferProduct");
            DropTable("Sales.ShoppingCartItem");
            DropTable("Production.ProductCategory");
            DropTable("Production.ProductSubcategory");
            DropTable("Production.ProductReview");
            DropTable("Production.ProductPhoto");
            DropTable("Production.ProductProductPhoto");
            DropTable("Production.ProductDescription");
            DropTable("Production.Culture");
            DropTable("Production.ProductModelProductDescriptionCulture");
            DropTable("Production.Illustration");
            DropTable("Production.ProductModelIllustration");
            DropTable("Production.ProductModel");
            DropTable("Production.ProductListPriceHistory");
            DropTable("Production.ScrapReason");
            DropTable("Production.WorkOrder");
            DropTable("Production.WorkOrderRouting");
            DropTable("Production.Location");
            DropTable("Production.ProductInventory");
            DropTable("Production.ProductDocument");
            DropTable("Production.ProductCostHistory");
            DropTable("Purchasing.Vendor");
            DropTable("Purchasing.ProductVendor");
            DropTable("Production.UnitMeasure");
            DropTable("Production.BillOfMaterials");
            DropTable("Production.Product");
            DropTable("Purchasing.PurchaseOrderDetail");
            DropTable("Purchasing.PurchaseOrderHeader");
            DropTable("HumanResources.JobCandidate");
            DropTable("HumanResources.EmployeePayHistory");
            DropTable("HumanResources.Shift");
            DropTable("HumanResources.Department");
            DropTable("HumanResources.EmployeeDepartmentHistory");
            DropTable("HumanResources.Employee");
            DropTable("Sales.SalesPerson");
            DropTable("Sales.Store");
            DropTable("Sales.Customer");
            DropTable("Sales.SalesTerritory");
            DropTable("Person.CountryRegion");
            DropTable("Sales.CountryRegionCurrency");
            DropTable("Sales.Currency");
            DropTable("Sales.CurrencyRate");
            DropTable("Sales.PersonCreditCard");
            DropTable("Sales.CreditCard");
            DropTable("Sales.SalesOrderHeader");
            DropTable("Person.Address");
            DropTable("Person.BusinessEntityAddress");
            DropTable("Person.BusinessEntity");
            DropTable("Person.Person");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
