namespace Bgts.Gps.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CompanyEmployeeWorkAtCity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyEmployeeWorkAtCity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        CityId = c.Int(nullable: false),
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
                    { "DynamicFilter_CompanyEmployeeWorkAtCity_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .Index(t => t.CompanyEmployeeId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyEmployeeWorkAtCity", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployeeWorkAtCity", "CityId", "dbo.City");
            DropIndex("dbo.CompanyEmployeeWorkAtCity", new[] { "CityId" });
            DropIndex("dbo.CompanyEmployeeWorkAtCity", new[] { "CompanyEmployeeId" });
            DropTable("dbo.CompanyEmployeeWorkAtCity",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeWorkAtCity_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
