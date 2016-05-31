namespace Bgts.Gps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Some_Indexs : DbMigration
    {
        public override void Up()
        {
            CreateIndex("CompanyBranchUser", new[] { "TenantId", "CompanyBranchId", "UserId" });
            CreateIndex("CompanyContact", new[] { "TenantId", "CompanyBranchId", "FirstName", "LastName" });
            CreateIndex("Patient", new[] { "TenantId", "CompanyBranchId", "FirstName", "LastName" });
            CreateIndex("SecurityRequiredLocation", new[] { "TenantId", "Zipcode" });
            CreateIndex("CompanyEmployee", new[] { "TenantId", "CompanyBranchId", "FirstName", "LastName" });
            CreateIndex("ActiveCode", new[] { "TenantId", "EmployeeId" });
        }
        
        public override void Down()
        {
            DropIndex("CompanyBranchUser", new[] { "TenantId", "CompanyBranchId", "UserId" });
            DropIndex("CompanyContact", new[] { "TenantId", "CompanyBranchId", "FirstName", "LastName" });
            DropIndex("Patient", new[] { "TenantId", "CompanyBranchId", "FirstName", "LastName" });
            DropIndex("SecurityRequiredLocation", new[] { "TenantId", "Zipcode" });
            DropIndex("CompanyEmployee", new[] { "TenantId", "CompanyBranchId", "FirstName", "LastName" });
            DropIndex("ActiveCode", new[] { "TenantId", "EmployeeId" });
        }
    }
}
