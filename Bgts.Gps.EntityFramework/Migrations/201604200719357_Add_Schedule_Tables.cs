namespace Bgts.Gps.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Schedule_Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobAccounting",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobMasterId = c.Long(),
                        BillingHours = c.Int(),
                        PayHours = c.Int(),
                        HoursCalculateIndicator = c.Int(),
                        PayIndicator = c.Boolean(),
                        BillingIndicator = c.Boolean(),
                        ChangedAfterBillGeneration = c.Boolean(),
                        Billed = c.Boolean(),
                        BillingControllId = c.Int(),
                        PayrollControlId = c.Int(),
                        InvoicedId = c.Int(),
                        PayrollProcessed = c.Boolean(),
                        PayrollId = c.Int(),
                        ClientEmployeeId = c.Long(),
                        AccountInvoiceNo = c.String(maxLength: 16),
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
                    { "DynamicFilter_JobAccounting_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobMaster", t => t.JobMasterId)
                .Index(t => t.JobMasterId);
            
            CreateTable(
                "dbo.JobMaster",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ScheduleId = c.Long(),
                        CompanyEmployeeTypeId = c.Int(),
                        CompanyEmployeeId = c.Long(),
                        CompanyEmployeeFirstName = c.String(maxLength: 16),
                        CompanyEmployeeLastName = c.String(maxLength: 16),
                        ClientEmployeeId = c.Long(),
                        ClientEmployeeFirstName = c.String(maxLength: 16),
                        ClientEmployeeLastName = c.String(maxLength: 16),
                        LanguageSkillId = c.Int(),
                        JobStatus = c.Int(),
                        TimeChanged = c.Boolean(),
                        EmployeeChanged = c.Boolean(),
                        AssignedJobTime = c.DateTime(),
                        ExpiredTime = c.DateTime(),
                        AcceptedTime = c.DateTime(),
                        RejectedTime = c.DateTime(),
                        CancelledTime = c.DateTime(),
                        ClientEmployeeActualStartTime = c.DateTime(),
                        ClientEmployeeActualEndTime = c.DateTime(),
                        CompanyEmployeeInitWaitTime = c.Int(),
                        ClientEmployeeSignatureTime = c.DateTime(),
                        ClientEmployeeSignature = c.String(maxLength: 128),
                        CompanyEmployeeCompletedTime = c.DateTime(),
                        TimeToFirstPatient = c.Int(),
                        LastPatientToDropOffTime = c.Int(),
                        TotalPatientVisitTime = c.Int(),
                        TotalOtherWaitTime = c.Int(),
                        TotalVisitBetweenTime = c.Int(),
                        TotalHoursWorked = c.Int(),
                        PercentProductiveTime = c.Double(),
                        TotalDownTime = c.Int(),
                        PercentDownTime = c.Double(),
                        MeetingAddress1 = c.String(maxLength: 64),
                        MeetingAddress2 = c.String(maxLength: 64),
                        MeetingCityId = c.Int(),
                        MeettingZipcode = c.String(maxLength: 10),
                        DropOffAddress1 = c.String(maxLength: 64),
                        DropOffAddress2 = c.String(maxLength: 64),
                        DropOffCityId = c.Int(),
                        DropOffZipcode = c.String(maxLength: 10),
                        JobComments = c.String(maxLength: 2048),
                        IsChanged = c.Boolean(),
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
                    { "DynamicFilter_JobMaster_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedule", t => t.ScheduleId)
                .Index(t => new { t.ScheduleId, t.CompanyEmployeeId, t.JobStatus }, name: "IX_JobMaster_ScheduleId_CompanyEmpoyeeId_JobStatus");
            
            CreateTable(
                "dbo.JobDetail",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobMasterId = c.Long(),
                        VisitNo = c.Long(),
                        FillStatus = c.Int(),
                        StartTime = c.DateTime(),
                        EndTime = c.DateTime(),
                        StartTimeEnteredAt = c.DateTime(),
                        EndTimeEnteredAt = c.DateTime(),
                        StartTimeMannuallyModified = c.Boolean(),
                        EndTimeMannuallyModified = c.Boolean(),
                        PatientId = c.Long(),
                        PatientAddress1 = c.String(maxLength: 64),
                        PatientAddress2 = c.String(maxLength: 64),
                        PatientCityId = c.Int(),
                        PatientZipcode = c.String(maxLength: 10),
                        PatientCensusTract = c.String(maxLength: 6),
                        PatientCensusBlockNumber = c.String(maxLength: 4),
                        TimeBetweenVisit = c.Int(),
                        RiskDesignation = c.Int(),
                        PolicyCompliance = c.Int(),
                        VisitType = c.Int(),
                        VisitDuration = c.Int(),
                        VisitComment = c.String(maxLength: 512),
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
                    { "DynamicFilter_JobDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobMaster", t => t.JobMasterId)
                .Index(t => t.JobMasterId);
            
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ClientBranchId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        CompanyBranchId = c.Int(nullable: false),
                        Department = c.Int(),
                        ScheduleStatus = c.Int(),
                        ScheduleDate = c.DateTime(),
                        ScheduleStartTime = c.DateTime(nullable: false),
                        ScheduleEndTime = c.DateTime(),
                        DayOfSchedule = c.Int(),
                        ShortDay = c.String(maxLength: 3),
                        Comments = c.String(maxLength: 512),
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
                    { "DynamicFilter_Schedule_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Schedule_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TenantId, t.ClientBranchId, t.CompanyBranchId, t.ScheduleStartTime }, name: "IX_Schedule_TenantId_ClientBranchId_CompanyBranchId_ScheduleStartTime");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobAccounting", "JobMasterId", "dbo.JobMaster");
            DropForeignKey("dbo.JobMaster", "ScheduleId", "dbo.Schedule");
            DropForeignKey("dbo.JobDetail", "JobMasterId", "dbo.JobMaster");
            DropIndex("dbo.Schedule", "IX_Schedule_TenantId_ClientBranchId_CompanyBranchId_ScheduleStartTime");
            DropIndex("dbo.JobDetail", new[] { "JobMasterId" });
            DropIndex("dbo.JobMaster", "IX_JobMaster_ScheduleId_CompanyEmpoyeeId_JobStatus");
            DropIndex("dbo.JobAccounting", new[] { "JobMasterId" });
            DropTable("dbo.Schedule",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Schedule_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_Schedule_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.JobDetail",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_JobDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.JobMaster",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_JobMaster_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.JobAccounting",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_JobAccounting_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
