using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WEBA_EF_CaseStudy2_Practise.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NIXH\SQLEXPRESS;Database=WEBA_EF_CasteStudyDB_2;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //---------- Defining Course Entity - Start ---------------
            //Make the CourseId a Primary Key and
            modelBuilder.Entity<Course>()
                .HasKey(input => input.CourseId)
                .HasName("PrimaryKey_CourseId");

            //Defining general property of CourseId
            modelBuilder.Entity<Course>()
                .Property(input => input.CourseId)
                .HasColumnName("CourseId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            //Defining general properties of CourseName
            modelBuilder.Entity<Course>()
                .Property(input => input.CourseName)
                .HasColumnName("CourseName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            //Defining general properties of CourseAbbreviation
            modelBuilder.Entity<Course>()
                .Property(input => input.CourseAbbreviation)
                .HasColumnName("CourseAbbreviation")
                .HasColumnType("VARCHAR(10)")
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(input => input.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Course>()
                .Property(input => input.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Course>()
                .Property(input => input.DeletedAt)
                .IsRequired(false);


            //Enforce unique constraint on Course Abbreviation
            modelBuilder.Entity<Course>()
                .HasIndex(input => input.CourseAbbreviation).IsUnique()
                .HasName("Course_CourseAbbreviation_UniqueConstraint");

            //---------- Defining Course Entity - End ------------------

            //---------- Defining Student Entity - Start ---------------
            //Make the StudentId a Primary Key and Identity column
            modelBuilder.Entity<Student>()
                .HasKey(input => input.StudentId)
                .HasName("PrimaryKey_StudentId");

            modelBuilder.Entity<Student>()
                .Property(input => input.StudentId)
                .HasColumnName("StudentId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            modelBuilder.Entity<Student>()
            .Property(input => input.AdmissionId)
            .HasColumnName("AdmissionId")
            .HasColumnType("VARCHAR(10)")
            .IsRequired(true);

            modelBuilder.Entity<Student>()
                .Property(input => input.MobileContact)
                .HasColumnName("MobileContact")
                .HasColumnType("VARCHAR(10)")
                .IsRequired(true);

            modelBuilder.Entity<Student>()
                .Property(input => input.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(50)")
                .IsRequired(true);

            modelBuilder.Entity<Student>()
                .Property(input => input.FullName)
                .HasColumnName("FullName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(input => input.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Student>()
                .Property(input => input.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Student>()
                .Property(input => input.DeletedAt)
                .IsRequired(false);

            //Enforce unique constraint on AdmissionId
            modelBuilder.Entity<Student>()
                .HasIndex(input => input.AdmissionId).IsUnique()
                .HasName("Student_AdmissionId_UniqueConstraint");

            //---------- Defining Student Entity - End ---------------

            //Establish one to many Relationship between Course and student
            modelBuilder.Entity<Student>()
                .HasOne(input => input.Course)
                .WithMany(input => input.Students)
                .HasForeignKey(input => input.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
