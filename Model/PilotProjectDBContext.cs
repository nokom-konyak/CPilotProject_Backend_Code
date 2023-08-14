using Microsoft.EntityFrameworkCore;
namespace Pilot_Project.Model
{
    public class PilotProjectDBContext:DbContext
    {
        
        public DbSet<EmployeeMasterData> EmployeeMasterData { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Course_Registration> Course_Registration { get; set; }

        public PilotProjectDBContext() : base() { }
        public PilotProjectDBContext(DbContextOptions<PilotProjectDBContext> options) : base(options) { }

        //protected void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Define composite primary key using Fluent API
        //    modelBuilder.Entity<Course_Registration>()
        //        .HasKey(cr => new { cr.EmployeeId, cr.CourseId });

        //    // Add other configurations as needed

        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=5420-TN81590\\SQLEXPRESS;Initial Catalog=PilotProjectDB;Integrated Security=true;Encrypt=true;TrustServerCertificate=true"));
        //}
    }
}
