namespace KaspiShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseOrderHeaderMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("Purchasing.PurchaseOrderHeader", "BusinessEntities_BusinessEntityID", c => c.Int());
            CreateIndex("Purchasing.PurchaseOrderHeader", "BusinessEntities_BusinessEntityID");
            AddForeignKey("Purchasing.PurchaseOrderHeader", "BusinessEntities_BusinessEntityID", "Person.BusinessEntity", "BusinessEntityID");
        }
        
        public override void Down()
        {
            DropForeignKey("Purchasing.PurchaseOrderHeader", "BusinessEntities_BusinessEntityID", "Person.BusinessEntity");
            DropIndex("Purchasing.PurchaseOrderHeader", new[] { "BusinessEntities_BusinessEntityID" });
            DropColumn("Purchasing.PurchaseOrderHeader", "BusinessEntities_BusinessEntityID");
        }
    }
}
