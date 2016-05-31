namespace Bgts.Gps.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_JobDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobDetail", "VisitReason", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobDetail", "VisitReason");
        }
    }
}
