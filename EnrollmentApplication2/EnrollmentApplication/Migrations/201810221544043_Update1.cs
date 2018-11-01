namespace EnrollmentApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Enrollments", "Grade", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Enrollments", "Grade", c => c.Int(nullable: false));
        }
    }
}
