namespace Bgts.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IX_For_Tables : DbMigration
    {
        public override void Up()
        {
            DropIndex("BCS_Permissions", new[] { "UserId" });
            DropIndex("BCS_Permissions", new[] { "RoleId" });
            DropIndex("BCS_Roles", new[] { "TenantId" });
            DropIndex("BCS_Settings", new[] { "TenantId" });
            DropIndex("BCS_Settings", new[] { "UserId" });
            DropIndex("BCS_UserLogins", new[] { "UserId" });
            DropIndex("BCS_UserRoles", new[] { "UserId" });
            DropIndex("BCS_Users", new[] { "TenantId" });

            CreateIndex("BCS_AuditLogs", new[] { "TenantId", "ExecutionTime" });
            CreateIndex("BCS_AuditLogs", new[] { "UserId", "ExecutionTime" });
            CreateIndex("BCS_Permissions", new[] { "UserId", "Name" });
            CreateIndex("BCS_Permissions", new[] { "RoleId", "Name" });
            CreateIndex("BCS_Roles", new[] { "TenantId", "Name" });
            CreateIndex("BCS_Roles", new[] { "IsDeleted", "TenantId", "Name" });
            CreateIndex("BCS_Settings", new[] { "TenantId", "Name" });
            CreateIndex("BCS_Settings", new[] { "UserId", "Name" });
            CreateIndex("BCS_Tenants", new[] { "TenancyName" });
            CreateIndex("BCS_Tenants", new[] { "IsDeleted", "TenancyName" });
            CreateIndex("BCS_UserLogins", new[] { "UserId", "LoginProvider" });
            CreateIndex("BCS_UserRoles", new[] { "UserId", "RoleId" });
            CreateIndex("BCS_UserRoles", new[] { "RoleId" });
            CreateIndex("BCS_Users", new[] { "TenantId", "UserName" });
            CreateIndex("BCS_Users", new[] { "TenantId", "EmailAddress" });
            CreateIndex("BCS_Users", new[] { "IsDeleted", "TenantId", "UserName" });
            CreateIndex("BCS_Users", new[] { "IsDeleted", "TenantId", "EmailAddress" });

            CreateIndex("BCS_Editions", new[] { "Name" });

            CreateIndex("BCS_Features", new[] { "Discriminator", "TenantId", "Name" });
            CreateIndex("BCS_Features", new[] { "Discriminator", "EditionId", "Name" });
            CreateIndex("BCS_Features", new[] { "TenantId", "Name" });

            CreateIndex("BCS_Languages", new[] { "TenantId", "Name" });

            CreateIndex("BCS_LanguageTexts", new[] { "TenantId", "LanguageName", "Source", "Key" });

            CreateIndex("BCS_OrganizationUnits", new[] { "TenantId", "ParentId" });
            CreateIndex("BCS_OrganizationUnits", new[] { "TenantId", "Code" });

            CreateIndex("BCS_UserOrganizationUnits", new[] { "TenantId", "UserId" });
            CreateIndex("BCS_UserOrganizationUnits", new[] { "TenantId", "OrganizationUnitId" });
            CreateIndex("BCS_UserOrganizationUnits", new[] { "UserId" });
            CreateIndex("BCS_UserOrganizationUnits", new[] { "OrganizationUnitId" });
        }

        public override void Down()
        {
            DropIndex("BCS_AuditLogs", new[] { "TenantId", "ExecutionTime" });
            DropIndex("BCS_AuditLogs", new[] { "UserId", "ExecutionTime" });
            DropIndex("BCS_Permissions", new[] { "UserId", "Name" });
            DropIndex("BCS_Permissions", new[] { "RoleId", "Name" });
            DropIndex("BCS_Roles", new[] { "TenantId", "Name" });
            DropIndex("BCS_Roles", new[] { "IsDeleted", "TenantId", "Name" });
            DropIndex("BCS_Settings", new[] { "TenantId", "Name" });
            DropIndex("BCS_Settings", new[] { "UserId", "Name" });
            DropIndex("BCS_Tenants", new[] { "TenancyName" });
            DropIndex("BCS_Tenants", new[] { "IsDeleted", "TenancyName" });
            DropIndex("BCS_UserLogins", new[] { "UserId", "LoginProvider" });
            DropIndex("BCS_UserRoles", new[] { "UserId", "RoleId" });
            DropIndex("BCS_UserRoles", new[] { "RoleId" });
            DropIndex("BCS_Users", new[] { "TenantId", "UserName" });
            DropIndex("BCS_Users", new[] { "TenantId", "EmailAddress" });
            DropIndex("BCS_Users", new[] { "IsDeleted", "TenantId", "UserName" });
            DropIndex("BCS_Users", new[] { "IsDeleted", "TenantId", "EmailAddress" });

            CreateIndex("BCS_Permissions", new[] { "UserId" });
            CreateIndex("BCS_Permissions", new[] { "RoleId" });
            CreateIndex("BCS_Roles", new[] { "TenantId" });
            CreateIndex("BCS_Settings", new[] { "TenantId" });
            CreateIndex("BCS_Settings", new[] { "UserId" });
            CreateIndex("BCS_UserLogins", new[] { "UserId" });
            CreateIndex("BCS_UserRoles", new[] { "UserId" });
            CreateIndex("BCS_Users", new[] { "TenantId" });

            DropIndex("BCS_Features", new[] { "TenantId", "Name" });
            DropIndex("BCS_Features", new[] { "Discriminator", "EditionId", "Name" });
            DropIndex("BCS_Features", new[] { "Discriminator", "TenantId", "Name" });

            DropIndex("BCS_Editions", new[] { "Name" });

            DropIndex("BCS_LanguageTexts", new[] { "TenantId", "LanguageName", "Source", "Key" });

            DropIndex("BCS_Languages", new[] { "TenantId", "Name" });

            DropIndex("BCS_UserOrganizationUnits", new[] { "OrganizationUnitId" });
            DropIndex("BCS_UserOrganizationUnits", new[] { "UserId" });
            DropIndex("BCS_UserOrganizationUnits", new[] { "TenantId", "OrganizationUnitId" });
            DropIndex("BCS_UserOrganizationUnits", new[] { "TenantId", "UserId" });

            DropIndex("BCS_OrganizationUnits", new[] { "TenantId", "Code" });
            DropIndex("BCS_OrganizationUnits", new[] { "TenantId", "ParentId" });
        }
    }
}
