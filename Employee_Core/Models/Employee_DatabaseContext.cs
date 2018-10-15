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
        public virtual DbSet<EmployeeDetail> EmployeeDetail { get; set; }

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
                entity.HasKey(e => e.City_ID);

                entity.Property(e => e.City_ID).HasColumnName("City_ID");

                entity.Property(e => e.City_Name)
                    .HasColumnName("City_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.State_ID).HasColumnName("State_ID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Department_ID); 

                entity.Property(e => e.Department_ID).HasColumnName("Department_ID");

                entity.Property(e => e.Department_Name)
                    .HasColumnName("Department_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Emp_ID);

                entity.Property(e => e.Emp_ID).HasColumnName("Emp_ID");

                entity.Property(e => e.Emp_City_ID).HasColumnName("Emp_City_ID");

                entity.Property(e => e.Emp_Dept_ID).HasColumnName("Emp_Dept_ID");

                entity.Property(e => e.Emp_Dob)
                    .HasColumnName("Emp_DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Emp_Doj)
                    .HasColumnName("Emp_DOJ")
                    .HasColumnType("date");

                entity.Property(e => e.Emp_Email_ID)
                    .HasColumnName("Emp_Email_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Emp_First_Name)
                    .HasColumnName("Emp_First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Emp_Last_Name)
                    .HasColumnName("Emp_Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Emp_Mobile_Number)
                    .HasColumnName("Emp_Mobile_Number")
                    .HasMaxLength(12);

                entity.Property(e => e.Emp_Rating)
                    .HasColumnName("Emp_Rating")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Emp_Skill_ID).HasColumnName("Emp_Skill_ID");

                entity.Property(e => e.Emp_State_ID).HasColumnName("Emp_State_ID");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.Rating_ID);

                entity.Property(e => e.Rating_ID)
                    .HasColumnName("Rating_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Rating_Name)
                    .HasColumnName("Rating_Name")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.Skill_ID);

                entity.Property(e => e.Skill_ID).HasColumnName("Skill_ID");

                entity.Property(e => e.Skill_Name)
                    .HasColumnName("Skill_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.State_ID);

                entity.Property(e => e.State_ID).HasColumnName("State_ID");

                entity.Property(e => e.State_Name)
                    .HasColumnName("State_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeDetail>(entity =>
            {
                entity.HasKey(e => e.Emp_ID);

                entity.Property(e => e.Emp_ID).HasColumnName("Emp_ID");

                entity.Property(e => e.Emp_City_ID).HasColumnName("Emp_City_ID");

                entity.Property(e => e.Emp_Dept_ID).HasColumnName("Emp_Dept_ID");

                entity.Property(e => e.Emp_DOB)
                    .HasColumnName("Emp_DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Emp_DOJ)
                    .HasColumnName("Emp_DOJ")
                    .HasColumnType("date");

                entity.Property(e => e.Emp_Email_ID)
                    .HasColumnName("Emp_Email_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Emp_First_Name)
                    .HasColumnName("Emp_First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Emp_Last_Name)
                    .HasColumnName("Emp_Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Emp_Mobile_Number)
                    .HasColumnName("Emp_Mobile_Number")
                    .HasMaxLength(12);

                entity.Property(e => e.Emp_Rating)
                    .HasColumnName("Emp_Rating")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Emp_Skill_ID).HasColumnName("Emp_Skill_ID");

                entity.Property(e => e.Emp_State_ID).HasColumnName("Emp_State_ID");

                entity.Property(e => e.City_Name)
                    .HasColumnName("City_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Department_Name)
                    .HasColumnName("Department_Name")
                    .HasMaxLength(50);                              

                entity.Property(e => e.Skill_Name)
                    .HasColumnName("Skill_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.State_Name)
                    .HasColumnName("State_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.City_ID)
                    .HasColumnName("City_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Department_ID)
                    .HasColumnName("Department_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.Skill_ID)
                    .HasColumnName("Skill_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.State_ID)
                    .HasColumnName("State_ID")
                    .HasMaxLength(50);
            });
        }
    }
}
