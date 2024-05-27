namespace KhoaHocOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Avatar = c.String(),
                        Password = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        DecentralizationID = c.Int(nullable: false),
                        ResetPasswordToken = c.String(),
                        ResetPasswordTokenExpiry = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.tb_Decentralization", t => t.DecentralizationID, cascadeDelete: true)
                .Index(t => t.DecentralizationID);
            
            CreateTable(
                "dbo.tb_Decentralization",
                c => new
                    {
                        DecentralizationID = c.Int(nullable: false, identity: true),
                        AuthorityName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DecentralizationID);
            
            CreateTable(
                "dbo.tb_Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        TotalMoney = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.tb_Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.tb_Enrollment",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        TutorID = c.Int(nullable: false),
                        StatusTypeID = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.tb_StatusType", t => t.StatusTypeID, cascadeDelete: true)
                .ForeignKey("dbo.tb_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.StatusTypeID);
            
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
            
            CreateTable(
                "dbo.tb_Fee",
                c => new
                    {
                        FeeID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        Status = c.String(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FeeID)
                .ForeignKey("dbo.tb_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.tb_PaymentHistory",
                c => new
                    {
                        PaymentHistoryID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        PaymentTypeID = c.Int(nullable: false),
                        PaymentName = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentHistoryID)
                .ForeignKey("dbo.tb_PaymentType", t => t.PaymentTypeID, cascadeDelete: true)
                .ForeignKey("dbo.tb_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.PaymentTypeID);
            
            CreateTable(
                "dbo.tb_PaymentType",
                c => new
                    {
                        PaymentTypeID = c.Int(nullable: false, identity: true),
                        PaymentTypeName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentTypeID);
            
            CreateTable(
                "dbo.tb_Submission",
                c => new
                    {
                        SubmissionID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        ExamTimes = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionID)
                .ForeignKey("dbo.tb_Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.tb_Tutors",
                c => new
                    {
                        TutorID = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        FullName = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TutorID)
                .ForeignKey("dbo.tb_Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.tb_Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false),
                        CourseDescription = c.String(nullable: false),
                        TutorID = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.tb_Tutors", t => t.TutorID, cascadeDelete: true)
                .Index(t => t.TutorID);
            
            CreateTable(
                "dbo.tb_CoursePart",
                c => new
                    {
                        CoursePartID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        PartTitle = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        IsWatched = c.Boolean(nullable: false),
                        IsWatching = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Index = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CoursePartID)
                .ForeignKey("dbo.tb_Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.tb_Exam",
                c => new
                    {
                        ExamID = c.Int(nullable: false, identity: true),
                        CoursePartID = c.Int(nullable: false),
                        ExamTypeID = c.Int(nullable: false),
                        ExamName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        WorkTime = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        MinGrade = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExamID)
                .ForeignKey("dbo.tb_CoursePart", t => t.CoursePartID, cascadeDelete: true)
                .ForeignKey("dbo.tb_ExamType", t => t.ExamTypeID, cascadeDelete: true)
                .Index(t => t.CoursePartID)
                .Index(t => t.ExamTypeID);
            
            CreateTable(
                "dbo.tb_ExamType",
                c => new
                    {
                        ExamTypeID = c.Int(nullable: false, identity: true),
                        ExamTypeName = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExamTypeID);
            
            CreateTable(
                "dbo.tb_Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        QuestionName = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.tb_Exam", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.tb_Answer",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        RightAnswer = c.Boolean(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.tb_Question", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
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
                .PrimaryKey(t => t.TutorAssignmentID)
                .ForeignKey("dbo.tb_Tutors", t => t.TutorID, cascadeDelete: true)
                .Index(t => t.TutorID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tb_VerifyCodes",
                c => new
                    {
                        VerifyCodeID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        ExpiredTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VerifyCodeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.tb_TutorAssignments", "TutorID", "dbo.tb_Tutors");
            DropForeignKey("dbo.tb_Course", "TutorID", "dbo.tb_Tutors");
            DropForeignKey("dbo.tb_Question", "ExamID", "dbo.tb_Exam");
            DropForeignKey("dbo.tb_Answer", "QuestionID", "dbo.tb_Question");
            DropForeignKey("dbo.tb_Exam", "ExamTypeID", "dbo.tb_ExamType");
            DropForeignKey("dbo.tb_Exam", "CoursePartID", "dbo.tb_CoursePart");
            DropForeignKey("dbo.tb_CoursePart", "CourseID", "dbo.tb_Course");
            DropForeignKey("dbo.tb_Tutors", "AccountID", "dbo.tb_Account");
            DropForeignKey("dbo.tb_Submission", "StudentID", "dbo.tb_Student");
            DropForeignKey("dbo.tb_PaymentHistory", "StudentID", "dbo.tb_Student");
            DropForeignKey("dbo.tb_PaymentHistory", "PaymentTypeID", "dbo.tb_PaymentType");
            DropForeignKey("dbo.tb_Fee", "StudentID", "dbo.tb_Student");
            DropForeignKey("dbo.tb_Enrollment", "StudentID", "dbo.tb_Student");
            DropForeignKey("dbo.tb_Enrollment", "StatusTypeID", "dbo.tb_StatusType");
            DropForeignKey("dbo.tb_Student", "AccountID", "dbo.tb_Account");
            DropForeignKey("dbo.tb_Account", "DecentralizationID", "dbo.tb_Decentralization");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.tb_TutorAssignments", new[] { "TutorID" });
            DropIndex("dbo.tb_Answer", new[] { "QuestionID" });
            DropIndex("dbo.tb_Question", new[] { "ExamID" });
            DropIndex("dbo.tb_Exam", new[] { "ExamTypeID" });
            DropIndex("dbo.tb_Exam", new[] { "CoursePartID" });
            DropIndex("dbo.tb_CoursePart", new[] { "CourseID" });
            DropIndex("dbo.tb_Course", new[] { "TutorID" });
            DropIndex("dbo.tb_Tutors", new[] { "AccountID" });
            DropIndex("dbo.tb_Submission", new[] { "StudentID" });
            DropIndex("dbo.tb_PaymentHistory", new[] { "PaymentTypeID" });
            DropIndex("dbo.tb_PaymentHistory", new[] { "StudentID" });
            DropIndex("dbo.tb_Fee", new[] { "StudentID" });
            DropIndex("dbo.tb_Enrollment", new[] { "StatusTypeID" });
            DropIndex("dbo.tb_Enrollment", new[] { "StudentID" });
            DropIndex("dbo.tb_Student", new[] { "AccountID" });
            DropIndex("dbo.tb_Account", new[] { "DecentralizationID" });
            DropTable("dbo.tb_VerifyCodes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.tb_TutorAssignments");
            DropTable("dbo.tb_Answer");
            DropTable("dbo.tb_Question");
            DropTable("dbo.tb_ExamType");
            DropTable("dbo.tb_Exam");
            DropTable("dbo.tb_CoursePart");
            DropTable("dbo.tb_Course");
            DropTable("dbo.tb_Tutors");
            DropTable("dbo.tb_Submission");
            DropTable("dbo.tb_PaymentType");
            DropTable("dbo.tb_PaymentHistory");
            DropTable("dbo.tb_Fee");
            DropTable("dbo.tb_StatusType");
            DropTable("dbo.tb_Enrollment");
            DropTable("dbo.tb_Student");
            DropTable("dbo.tb_Decentralization");
            DropTable("dbo.tb_Account");
        }
    }
}
