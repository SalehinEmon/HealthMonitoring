namespace HealthMonitoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class make_dateofbirth_as_model : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DateOfBirth");
        }
    }
}
