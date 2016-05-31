namespace Bgts.Gps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_CompanyBranch : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyBranch", "Address1", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CompanyBranch", "Address1", c => c.String(maxLength: 64));
        }
    }
}
