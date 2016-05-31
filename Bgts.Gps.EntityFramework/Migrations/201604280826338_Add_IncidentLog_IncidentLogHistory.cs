namespace Bgts.Gps.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IncidentLog_IncidentLogHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncidentLogHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncidentLogId = c.Long(),
                        IncidentAction = c.Int(),
                        Comment = c.String(maxLength: 256),
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
                    { "DynamicFilter_IncidentLogHistory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IncidentLog", t => t.IncidentLogId)
                .Index(t => t.IncidentLogId);
            
            CreateTable(
                "dbo.IncidentLog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IncidentKind = c.Int(nullable: false),
                        IncidentType = c.Int(nullable: false),
                        IncidentSubType = c.Int(nullable: false),
                        IncidentTarget = c.Int(nullable: false),
                        IncidentSourceType = c.Int(nullable: false),
                        IncidentSourceDesc = c.String(nullable: false, maxLength: 64),
                        IncidentSourceIdDesc = c.String(nullable: false, maxLength: 256),
                        OccurredTime = c.DateTime(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 256),
                        Priority = c.Int(nullable: false),
                        ActionRequired = c.Boolean(),
                        Status = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        ConditionCode = c.Int(nullable: false),
                        CompanyEmployeeId = c.Long(),
                        ClientId = c.Int(),
                        ClientBranchId = c.Int(),
                        ClientEmployeeId = c.Long(),
                        PatientId = c.Long(),
                        CompanyId = c.Int(),
                        CompanyBranchId = c.Int(),
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
                    { "DynamicFilter_IncidentLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IncidentLog_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncidentLogHistory", "IncidentLogId", "dbo.IncidentLog");
            DropIndex("dbo.IncidentLogHistory", new[] { "IncidentLogId" });
            DropTable("dbo.IncidentLog",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_IncidentLog_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_IncidentLog_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.IncidentLogHistory",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_IncidentLogHistory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
