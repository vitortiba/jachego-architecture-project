namespace Jachego.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carriers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Document = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Email = c.String(nullable: false, maxLength: 11, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Document = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Email = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Phone = c.String(nullable: false, maxLength: 11, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Parcels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DeliveryInterval_StartDeliveryDate = c.DateTime(nullable: false),
                        DeliveryInterval_ExpectedDeliveryDate = c.DateTime(nullable: false),
                        Code = c.String(nullable: false, maxLength: 128),
                        Carrier_Id = c.Guid(nullable: false),
                        Customer_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carriers", t => t.Carrier_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.TrackingCodes", t => t.Code, cascadeDelete: true)
                .Index(t => t.Code)
                .Index(t => t.Carrier_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.TrackingCodes",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Carrier_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Carriers", t => t.Carrier_Id)
                .Index(t => t.Carrier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcels", "Code", "dbo.TrackingCodes");
            DropForeignKey("dbo.TrackingCodes", "Carrier_Id", "dbo.Carriers");
            DropForeignKey("dbo.Parcels", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Parcels", "Carrier_Id", "dbo.Carriers");
            DropIndex("dbo.TrackingCodes", new[] { "Carrier_Id" });
            DropIndex("dbo.Parcels", new[] { "Customer_Id" });
            DropIndex("dbo.Parcels", new[] { "Carrier_Id" });
            DropIndex("dbo.Parcels", new[] { "Code" });
            DropTable("dbo.TrackingCodes");
            DropTable("dbo.Parcels");
            DropTable("dbo.Customers");
            DropTable("dbo.Carriers");
        }
    }
}
