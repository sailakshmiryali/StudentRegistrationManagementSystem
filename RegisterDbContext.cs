using CourseRegister.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseRegister.Data
{
    public class RegisterDbContext : DbContext
    {
        public RegisterDbContext(
            DbContextOptions<RegisterDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Course> Courses { get; set; }

        public DbSet<Register> Registrations { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Course>().HasData(
                    new Course { CourseId = 1, CourseName = ".NET Full Stack" },
                    new Course { CourseId = 2, CourseName = "Java Full Stack" },
                    new Course { CourseId = 3, CourseName = "Python Full Stack" },
                    new Course { CourseId = 4, CourseName = "Angular" }
                );

                modelBuilder.Entity<Register>()
                    .HasOne(r => r.Course)
                    .WithMany(c => c.Registrations)
                    .HasForeignKey(r => r.CourseId);
            }
        }
    }
