namespace Bgts.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_UserLoginAttempt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BCS_UserLoginAttempts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        TenancyName = c.String(maxLength: 64),
                        UserId = c.Long(),
                        UserNameOrEmailAddress = c.String(maxLength: 256),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        BrowserInfo = c.String(maxLength: 256),
                        Result = c.Byte(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TenancyName, t.UserNameOrEmailAddress, t.Result });
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BCS_UserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            DropTable("dbo.BCS_UserLoginAttempts");
        }
    }
}
