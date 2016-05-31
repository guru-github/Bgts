namespace Bgts.Gps.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 64),
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
                    { "DynamicFilter_Area_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Area_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 32),
                        State = c.String(nullable: false, maxLength: 32),
                        Country = c.String(maxLength: 8),
                        TimezoneId = c.Int(nullable: false),
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
                    { "DynamicFilter_City_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_City_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Timezone", t => t.TimezoneId)
                .Index(t => t.TimezoneId);
            
            CreateTable(
                "dbo.Timezone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimezoneCode = c.String(nullable: false, maxLength: 6),
                        Description = c.String(nullable: false, maxLength: 32),
                        IsNegativeGMT = c.Boolean(nullable: false),
                        GMTOffsetTime = c.Int(nullable: false),
                        DaylightSaving = c.String(maxLength: 64),
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
                    { "DynamicFilter_Timezone_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Timezone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientBranch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(maxLength: 64),
                        ServiceType = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Address1 = c.String(maxLength: 64),
                        Address2 = c.String(maxLength: 64),
                        CityId = c.Int(nullable: false),
                        Zipcode = c.String(maxLength: 10),
                        Fax = c.String(maxLength: 16),
                        ContactName = c.String(maxLength: 32),
                        ContactPhone = c.String(maxLength: 16),
                        EmergName = c.String(maxLength: 32),
                        EmergPhone = c.String(maxLength: 16),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        ARAccountId = c.Int(nullable: false),
                        SalesAccountId = c.Int(nullable: false),
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
                    { "DynamicFilter_ClientBranch_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ClientBranch_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .ForeignKey("dbo.ClientBranch", t => t.ParentId)
                .Index(t => t.ClientId)
                .Index(t => t.ParentId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        DefaultServiceType = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Address1 = c.String(nullable: false, maxLength: 64),
                        Address2 = c.String(maxLength: 64),
                        CityId = c.Int(nullable: false),
                        Zipcode = c.String(nullable: false),
                        AltBillAddress = c.String(maxLength: 64),
                        AltName = c.String(maxLength: 64),
                        AltAddress1 = c.String(maxLength: 64),
                        AltAddress2 = c.String(maxLength: 64),
                        AltCityId = c.Int(),
                        AltZipcode = c.String(maxLength: 10),
                        Fax = c.String(maxLength: 16),
                        Email = c.String(maxLength: 64),
                        OtherInfo1 = c.String(maxLength: 64),
                        OtherInfo2 = c.String(maxLength: 64),
                        ContactName = c.String(maxLength: 32),
                        ContactPhone = c.String(maxLength: 16),
                        EmergName = c.String(maxLength: 32),
                        EmergPhone = c.String(maxLength: 16),
                        AccPayName = c.String(maxLength: 32),
                        AccPayPhone = c.String(maxLength: 16),
                        PaymentTerms = c.Int(nullable: false),
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
                    { "DynamicFilter_Client_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Client_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 64),
                        DefaultServiceType = c.Int(nullable: false),
                        Address1 = c.String(nullable: false, maxLength: 64),
                        Address2 = c.String(maxLength: 64),
                        CityId = c.Int(nullable: false),
                        PhoneNo = c.String(maxLength: 16),
                        Fax = c.String(maxLength: 16),
                        Zipcode = c.String(maxLength: 10),
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
                    { "DynamicFilter_Company_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Company_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyBranch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Code = c.String(maxLength: 95),
                        BranchName = c.String(nullable: false, maxLength: 32),
                        Address1 = c.String(maxLength: 64),
                        Address2 = c.String(maxLength: 64),
                        CityId = c.Int(),
                        Zipcode = c.String(maxLength: 10),
                        Fax = c.String(maxLength: 16),
                        ContactName = c.String(maxLength: 32),
                        ContactPhone = c.String(maxLength: 16),
                        EmergName = c.String(maxLength: 32),
                        EmergPhone = c.String(maxLength: 32),
                        CompanyId = c.Int(),
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
                    { "DynamicFilter_CompanyBranch_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyBranch_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyBranch", t => t.ParentId)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .Index(t => t.ParentId)
                .Index(t => t.CityId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyBranchUser",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        UserId = c.Long(nullable: false),
                        BranchId = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyBranchUser_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyContact",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 16),
                        LastName = c.String(nullable: false, maxLength: 16),
                        Department = c.Int(nullable: false),
                        ContactType = c.Int(nullable: false),
                        Email = c.String(maxLength: 32),
                        TelNo1Type = c.Int(nullable: false),
                        TelNo1 = c.String(nullable: false, maxLength: 16),
                        TelNo2Type = c.Int(nullable: false),
                        TelNo2 = c.String(maxLength: 16),
                        TelNo3Type = c.Int(nullable: false),
                        TelNo3 = c.String(maxLength: 16),
                        TelNo4Type = c.Int(nullable: false),
                        TelNo4 = c.String(maxLength: 16),
                        Comment = c.String(maxLength: 512),
                        IsActive = c.Boolean(nullable: false),
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
                    { "DynamicFilter_CompanyContact_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyContact_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyBranch", t => t.CompanyBranchId)
                .Index(t => t.CompanyBranchId);
            
            CreateTable(
                "dbo.CompanyEmployeeAbsence",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        Pending = c.Boolean(nullable: false),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        Reason = c.String(maxLength: 64),
                        Comment = c.String(maxLength: 512),
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
                    { "DynamicFilter_CompanyEmployeeAbsence_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .Index(t => t.CompanyEmployeeId);
            
            CreateTable(
                "dbo.CompanyEmployee",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 16),
                        MiddleInitial = c.String(maxLength: 16),
                        LastName = c.String(nullable: false, maxLength: 16),
                        IsActive = c.Boolean(nullable: false),
                        SSN = c.String(maxLength: 16),
                        Address1 = c.String(maxLength: 256),
                        Address2 = c.String(maxLength: 256),
                        CityId = c.Int(nullable: false),
                        Zipcode = c.String(maxLength: 10),
                        HomeCityId = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                        PhoneNo = c.String(maxLength: 16),
                        EmergName = c.String(maxLength: 32),
                        EmergPhone = c.String(maxLength: 16),
                        OtherEmployeeId = c.String(maxLength: 40),
                        Gender = c.Boolean(nullable: false),
                        InactiveDate = c.DateTime(),
                        InactivateReasonId = c.Int(),
                        InactiveReasonComments = c.String(maxLength: 256),
                        DateHired = c.DateTime(),
                        FirstDateWorked = c.DateTime(),
                        LastDateWorked = c.DateTime(),
                        AutoCalcFirstDtWork = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(),
                        Height = c.String(maxLength: 8),
                        Weight = c.String(maxLength: 8),
                        BackGroundVerified = c.Boolean(nullable: false),
                        Rehirable = c.Boolean(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comments = c.String(maxLength: 512),
                        CompanyBranchId = c.Int(),
                        EmployeeTypeId = c.Int(),
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
                    { "DynamicFilter_CompanyEmployee_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyEmployee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Area", t => t.AreaId)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.CompanyBranch", t => t.CompanyBranchId)
                .ForeignKey("dbo.CompanyEmployeeType", t => t.EmployeeTypeId)
                .ForeignKey("dbo.City", t => t.HomeCityId)
                .ForeignKey("dbo.InactiveReason", t => t.InactivateReasonId)
                .Index(t => t.CityId)
                .Index(t => t.HomeCityId)
                .Index(t => t.AreaId)
                .Index(t => t.InactivateReasonId)
                .Index(t => t.CompanyBranchId)
                .Index(t => t.EmployeeTypeId);
            
            CreateTable(
                "dbo.CompanyEmployeeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 128),
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
                    { "DynamicFilter_CompanyEmployeeType_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyEmployeeType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InactiveReason",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 64),
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
                    { "DynamicFilter_InactiveReason_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_InactiveReason_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyEmployeeBan",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        BanType = c.Int(nullable: false),
                        BanAction = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ClientBranchId = c.Int(nullable: false),
                        Reason = c.String(maxLength: 256),
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
                    { "DynamicFilter_CompanyEmployeeBan_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .ForeignKey("dbo.ClientBranch", t => t.ClientBranchId)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .Index(t => t.CompanyEmployeeId)
                .Index(t => t.ClientId)
                .Index(t => t.ClientBranchId);
            
            CreateTable(
                "dbo.CompanyEmployeeDaysNotAvailable",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                        ShortDay = c.String(maxLength: 3),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        OnCall = c.Boolean(nullable: false),
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
                    { "DynamicFilter_CompanyEmployeeDaysNotAvailable_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .Index(t => t.CompanyEmployeeId);
            
            CreateTable(
                "dbo.CompanyEmployeeEmail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        Email = c.String(maxLength: 64),
                        DisplayName = c.String(maxLength: 32),
                        FirstName = c.String(maxLength: 16),
                        LastName = c.String(maxLength: 16),
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
                    { "DynamicFilter_CompanyEmployeeEmail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .Index(t => t.CompanyEmployeeId);
            
            CreateTable(
                "dbo.CompanyEmployeePicture",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        SeqNo = c.Int(nullable: false),
                        FileName = c.String(maxLength: 16),
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
                    { "DynamicFilter_CompanyEmployeePicture_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .Index(t => t.CompanyEmployeeId);
            
            CreateTable(
                "dbo.CompanyEmployeeSkill",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        SkillId = c.Int(nullable: false),
                        OtherInfo = c.String(maxLength: 256),
                        EffectiveDate = c.DateTime(),
                        ProvideBy = c.String(maxLength: 128),
                        ExpiryDate = c.DateTime(),
                        CanExpiry = c.Boolean(nullable: false),
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
                    { "DynamicFilter_CompanyEmployeeSkill_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .ForeignKey("dbo.Skill", t => t.SkillId)
                .Index(t => t.CompanyEmployeeId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillType = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 64),
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
                    { "DynamicFilter_Skill_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Skill_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyEmployeeTelephone",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CompanyEmployeeId = c.Long(nullable: false),
                        TelType = c.Int(nullable: false),
                        SeqNo = c.Int(nullable: false),
                        PhoneNo = c.String(maxLength: 16),
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
                    { "DynamicFilter_CompanyEmployeeTelephone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompanyEmployee", t => t.CompanyEmployeeId)
                .Index(t => t.CompanyEmployeeId);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 16),
                        LastName = c.String(nullable: false, maxLength: 16),
                        Address = c.String(nullable: false, maxLength: 512),
                        CityId = c.Int(nullable: false),
                        Zipcode = c.String(nullable: false, maxLength: 10),
                        CensusTract = c.String(maxLength: 6),
                        CensusBlockNumber = c.String(maxLength: 4),
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
                    { "DynamicFilter_Patient_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Patient_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.SecurityRequiredLocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Zipcode = c.String(nullable: false, maxLength: 10),
                        CensusTract = c.String(maxLength: 6),
                        CensusBlockNumber = c.String(maxLength: 4),
                        ZipPlus4 = c.String(maxLength: 4),
                        City = c.String(nullable: false, maxLength: 64),
                        State = c.String(maxLength: 64),
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
                    { "DynamicFilter_SecurityRequiredLocation_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SecurityRequiredLocation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "CityId", "dbo.City");
            DropForeignKey("dbo.CompanyEmployeeTelephone", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployeeSkill", "SkillId", "dbo.Skill");
            DropForeignKey("dbo.CompanyEmployeeSkill", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployeePicture", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployeeEmail", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployeeDaysNotAvailable", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployeeBan", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployeeBan", "ClientBranchId", "dbo.ClientBranch");
            DropForeignKey("dbo.CompanyEmployeeBan", "ClientId", "dbo.Client");
            DropForeignKey("dbo.CompanyEmployeeAbsence", "CompanyEmployeeId", "dbo.CompanyEmployee");
            DropForeignKey("dbo.CompanyEmployee", "InactivateReasonId", "dbo.InactiveReason");
            DropForeignKey("dbo.CompanyEmployee", "HomeCityId", "dbo.City");
            DropForeignKey("dbo.CompanyEmployee", "EmployeeTypeId", "dbo.CompanyEmployeeType");
            DropForeignKey("dbo.CompanyEmployee", "CompanyBranchId", "dbo.CompanyBranch");
            DropForeignKey("dbo.CompanyEmployee", "CityId", "dbo.City");
            DropForeignKey("dbo.CompanyEmployee", "AreaId", "dbo.Area");
            DropForeignKey("dbo.CompanyContact", "CompanyBranchId", "dbo.CompanyBranch");
            DropForeignKey("dbo.CompanyBranch", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.CompanyBranch", "CityId", "dbo.City");
            DropForeignKey("dbo.CompanyBranch", "ParentId", "dbo.CompanyBranch");
            DropForeignKey("dbo.ClientBranch", "ParentId", "dbo.ClientBranch");
            DropForeignKey("dbo.ClientBranch", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Client", "CityId", "dbo.City");
            DropForeignKey("dbo.ClientBranch", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "TimezoneId", "dbo.Timezone");
            DropIndex("dbo.Patient", new[] { "CityId" });
            DropIndex("dbo.CompanyEmployeeTelephone", new[] { "CompanyEmployeeId" });
            DropIndex("dbo.CompanyEmployeeSkill", new[] { "SkillId" });
            DropIndex("dbo.CompanyEmployeeSkill", new[] { "CompanyEmployeeId" });
            DropIndex("dbo.CompanyEmployeePicture", new[] { "CompanyEmployeeId" });
            DropIndex("dbo.CompanyEmployeeEmail", new[] { "CompanyEmployeeId" });
            DropIndex("dbo.CompanyEmployeeDaysNotAvailable", new[] { "CompanyEmployeeId" });
            DropIndex("dbo.CompanyEmployeeBan", new[] { "ClientBranchId" });
            DropIndex("dbo.CompanyEmployeeBan", new[] { "ClientId" });
            DropIndex("dbo.CompanyEmployeeBan", new[] { "CompanyEmployeeId" });
            DropIndex("dbo.CompanyEmployee", new[] { "EmployeeTypeId" });
            DropIndex("dbo.CompanyEmployee", new[] { "CompanyBranchId" });
            DropIndex("dbo.CompanyEmployee", new[] { "InactivateReasonId" });
            DropIndex("dbo.CompanyEmployee", new[] { "AreaId" });
            DropIndex("dbo.CompanyEmployee", new[] { "HomeCityId" });
            DropIndex("dbo.CompanyEmployee", new[] { "CityId" });
            DropIndex("dbo.CompanyEmployeeAbsence", new[] { "CompanyEmployeeId" });
            DropIndex("dbo.CompanyContact", new[] { "CompanyBranchId" });
            DropIndex("dbo.CompanyBranch", new[] { "CompanyId" });
            DropIndex("dbo.CompanyBranch", new[] { "CityId" });
            DropIndex("dbo.CompanyBranch", new[] { "ParentId" });
            DropIndex("dbo.Client", new[] { "CityId" });
            DropIndex("dbo.ClientBranch", new[] { "CityId" });
            DropIndex("dbo.ClientBranch", new[] { "ParentId" });
            DropIndex("dbo.ClientBranch", new[] { "ClientId" });
            DropIndex("dbo.City", new[] { "TimezoneId" });
            DropTable("dbo.SecurityRequiredLocation",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_SecurityRequiredLocation_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_SecurityRequiredLocation_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Patient",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Patient_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Patient_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeeTelephone",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeTelephone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Skill",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Skill_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Skill_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeeSkill",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeSkill_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeePicture",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeePicture_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeeEmail",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeEmail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeeDaysNotAvailable",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeDaysNotAvailable_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeeBan",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeBan_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.InactiveReason",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_InactiveReason_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_InactiveReason_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeeType",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeType_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyEmployeeType_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployee",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployee_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyEmployee_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyEmployeeAbsence",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyEmployeeAbsence_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyContact",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyContact_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyContact_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyBranchUser",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyBranchUser_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.CompanyBranch",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_CompanyBranch_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_CompanyBranch_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Company",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Company_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Company_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Client",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Client_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Client_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ClientBranch",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ClientBranch_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_ClientBranch_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Timezone",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Timezone_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Timezone_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.City",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_City_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_City_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Area",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Area_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Area_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
