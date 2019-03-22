using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SechedulingMVCAppReamer.Models;

namespace SechedulingMVCAppReamer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<DepartmentChair>  DepartmentChairs { get; set; }

        public DbSet<ConflictCourse> ConflictCourses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<CourseOffering> CourseOfferings { get; set; }

        public DbSet<TeachingQualification> TeachingQualifications { get; set; }

        public DbSet<CourseOfferingChanges> CourseOfferingChanges { get; set; }

    }
}
