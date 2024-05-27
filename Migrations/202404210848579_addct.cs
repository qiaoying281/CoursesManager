namespace KhoaHocOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Enrollment", "StatusTypeID", "dbo.tb_StatusType");
            DropForeignKey("dbo.tb_TutorAssignments", "TutorID", "dbo.tb_Tutors");
            DropIndex("dbo.tb_Enrollment", new[] { "StatusTypeID" });
            DropIndex("dbo.tb_TutorAssignments", new[] { "TutorID" });
            CreateTable(
                "dbo.tb_CourseType",
                c => new
                    {
                        CourseTypeID = c.Int(nullable: false, identity: true),
                        CourseTypeName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseTypeID);
            
            AddColumn("dbo.tb_Course", "CourseTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Course", "CourseTypeID");
            AddForeignKey("dbo.tb_Course", "CourseTypeID", "dbo.tb_CourseType", "CourseTypeID", cascadeDelete: true);
            DropColumn("dbo.tb_Enrollment", "TutorID");
            DropColumn("dbo.tb_Enrollment", "StatusTypeID");
            DropTable("dbo.tb_StatusType");
            DropTable("dbo.tb_TutorAssignments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_TutorAssignments",
                c => new
                    {
                        TutorAssignmentID = c.Int(nullable: false, identity: true),
                        TutorID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        NumberOfStudent = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TutorAssignmentID);
            
            CreateTable(
                "dbo.tb_StatusType",
                c => new
                    {
                        StatusTypeID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StatusTypeID);
            
            AddColumn("dbo.tb_Enrollment", "StatusTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Enrollment", "TutorID", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_Course", "CourseTypeID", "dbo.tb_CourseType");
            DropIndex("dbo.tb_Course", new[] { "CourseTypeID" });
            DropColumn("dbo.tb_Course", "CourseTypeID");
            DropTable("dbo.tb_CourseType");
            CreateIndex("dbo.tb_TutorAssignments", "TutorID");
            CreateIndex("dbo.tb_Enrollment", "StatusTypeID");
            AddForeignKey("dbo.tb_TutorAssignments", "TutorID", "dbo.tb_Tutors", "TutorID", cascadeDelete: true);
            AddForeignKey("dbo.tb_Enrollment", "StatusTypeID", "dbo.tb_StatusType", "StatusTypeID", cascadeDelete: true);
        }
    }
}
