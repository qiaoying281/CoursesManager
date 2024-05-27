using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using KhoaHocOnline.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace KhoaHocOnline.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Phone {  get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CoursePart> CourseParts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Decentralization> Decentralizations { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<PaymentHistory> PaymentHistorys { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<VerifyCode> VerifyCodes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}