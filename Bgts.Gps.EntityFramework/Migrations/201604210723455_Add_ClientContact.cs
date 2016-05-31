namespace Bgts.Gps.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ClientContact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientContact",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClientBranchId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 16),
                        LastName = c.String(nullable: false, maxLength: 16),
                        Department = c.Int(),
                        ContactType = c.Int(),
                        Email = c.String(maxLength: 32),
                        TelNo1Type = c.Int(nullable: false),
                        TelNo1 = c.String(nullable: false, maxLength: 16),
                        TelNo2Type = c.Int(),
                        TelNo2 = c.String(maxLength: 16),
                        TelNo3Type = c.Int(),
                        TelNo3 = c.String(maxLength: 16),
                        TelNo4Type = c.Int(),
                        TelNo4 = c.String(maxLength: 16),
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
                    { "DynamicFilter_ClientContact_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ClientContact_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientBranch", t => t.ClientBranchId)
                .Index(t => t.ClientBranchId);
            
            AddColumn("dbo.ClientBranch", "Code", c => c.String(maxLength: 128));
            AddColumn("dbo.ClientBranch", "BranchName", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Client", "ContactName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Client", "EmergName", c => c.String(maxLength: 32));
            AlterColumn("dbo.Client", "PaymentTerms", c => c.Int());
            DropColumn("dbo.ClientBranch", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ClientBranch", "Name", c => c.String(nullable: false, maxLength: 64));
            DropForeignKey("dbo.ClientContact", "ClientBranchId", "dbo.ClientBranch");
            DropIndex("dbo.ClientContact", new[] { "ClientBranchId" });
            AlterColumn("dbo.Client", "PaymentTerms", c => c.Int(nullable: false));
            AlterColumn("dbo.Client", "EmergName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.Client", "ContactName", c => c.String(maxLength: 32));
            DropColumn("dbo.ClientBranch", "BranchName");
            DropColumn("dbo.ClientBranch", "Code");
            DropTable("dbo.ClientContact",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ClientContact_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ClientContact_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
