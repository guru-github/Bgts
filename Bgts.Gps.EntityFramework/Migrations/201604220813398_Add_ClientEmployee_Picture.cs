namespace Bgts.Gps.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ClientEmployee_Picture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientEmployeePicture",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClientEmployeeId = c.Long(nullable: false),
                        SeqNo = c.Int(),
                        FileName = c.String(maxLength: 64),
                        Description = c.String(maxLength: 256),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ClientEmployeePicture_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEmployee", t => t.ClientEmployeeId)
                .Index(t => t.ClientEmployeeId);
            
            CreateTable(
                "dbo.ClientEmployee",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClientBranchId = c.Int(),
                        OtherEmployeeId = c.String(maxLength: 40),
                        FirstName = c.String(nullable: false, maxLength: 16),
                        MiddleInitial = c.String(maxLength: 16),
                        LastName = c.String(nullable: false, maxLength: 16),
                        Address1 = c.String(nullable: false, maxLength: 16),
                        Address2 = c.String(maxLength: 16),
                        CityId = c.Int(nullable: false),
                        Zipcode = c.String(maxLength: 10),
                        PhoneNo = c.String(nullable: false, maxLength: 128),
                        EmergName = c.String(maxLength: 32),
                        EmergPhone = c.String(maxLength: 16),
                        Gender = c.Boolean(),
                        Comment = c.String(maxLength: 512),
                        IsActive = c.Boolean(nullable: false),
                        TenantId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ClientEmployee_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ClientEmployee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.ClientBranch", t => t.ClientBranchId)
                .Index(t => t.ClientBranchId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientEmployeePicture", "ClientEmployeeId", "dbo.ClientEmployee");
            DropForeignKey("dbo.ClientEmployee", "ClientBranchId", "dbo.ClientBranch");
            DropForeignKey("dbo.ClientEmployee", "CityId", "dbo.City");
            DropIndex("dbo.ClientEmployee", new[] { "CityId" });
            DropIndex("dbo.ClientEmployee", new[] { "ClientBranchId" });
            DropIndex("dbo.ClientEmployeePicture", new[] { "ClientEmployeeId" });
            DropTable("dbo.ClientEmployee",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ClientEmployee_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ClientEmployee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ClientEmployeePicture",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ClientEmployeePicture_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
