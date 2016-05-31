namespace Bgts.Gps.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ActiveCode_Update_CompanyEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActiveCode",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(),
                        EmployeeId = c.Long(nullable: false),
                        FirstName = c.String(maxLength: 16),
                        LastName = c.String(maxLength: 16),
                        PhoneNo = c.String(maxLength: 16),
                        WorkType = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 8),
                        GenerateTime = c.DateTime(),
                        ExpiryTime = c.DateTime(),
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
                    { "DynamicFilter_ActiveCode_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ActiveCode_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true, name: "IX_UNQ_ActiveCode_Code");
            
            AlterColumn("dbo.CompanyEmployee", "PhoneNo", c => c.String(nullable: false, maxLength: 16));
        }
        
        public override void Down()
        {
            DropIndex("dbo.ActiveCode", "IX_UNQ_ActiveCode_Code");
            AlterColumn("dbo.CompanyEmployee", "PhoneNo", c => c.String(maxLength: 16));
            DropTable("dbo.ActiveCode",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ActiveCode_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ActiveCode_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
