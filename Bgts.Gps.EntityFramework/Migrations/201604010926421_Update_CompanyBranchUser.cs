namespace Bgts.Gps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_CompanyBranchUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyBranchUser", "CompanyBranchId", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyBranchUser", "BranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyBranchUser", "BranchId", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyBranchUser", "CompanyBranchId");
        }
    }
}
