using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Employee_Core.Models
{
    public partial class Employee_DatabaseContext : DbContext
    {
        public Employee_DatabaseContext()
        {
        }

        public Employee_DatabaseContext(DbContextOptions<Employee_DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<State> State { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=HP\\SQLEXPRESS;Database=Employee_Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.CityName)
                    .HasColumnName("City_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.StateId).HasColumnName("State_ID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");

                entity.Property(e => e.DepartmentName)
                    .HasColumnName("Department_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.EmpCityId).HasColumnName("Emp_City_ID");

                entity.Property(e => e.EmpDeptId).HasColumnName("Emp_Dept_ID");

                entity.Property(e => e.EmpDob)
                    .HasColumnName("Emp_DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmpDoj)
                    .HasColumnName("Emp_DOJ")
                    .HasColumnType("date");

                entity.Property(e => e.EmpEmailId)
                    .HasColumnName("Emp_Email_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpFirstName)
                    .HasColumnName("Emp_First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpLastName)
                    .HasColumnName("Emp_Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpMobileNumber)
                    .HasColumnName("Emp_Mobile_Number")
                    .HasMaxLength(12);

                entity.Property(e => e.EmpRating)
                    .HasColumnName("Emp_Rating")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSkillId).HasColumnName("Emp_Skill_ID");

                entity.Property(e => e.EmpStateId).HasColumnName("Emp_State_ID");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.Property(e => e.RatingId)
                    .HasColumnName("Rating_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RatingName)
                    .HasColumnName("Rating_Name")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.SkillId).HasColumnName("Skill_ID");

                entity.Property(e => e.SkillName)
                    .HasColumnName("Skill_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.StateId).HasColumnName("State_ID");

                entity.Property(e => e.StateName)
                    .HasColumnName("State_Name")
                    .HasMaxLength(50);
            });
        }
    }
}
