using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WEBA_EF_CaseStudy2_Practise.Models;

namespace WEBA_EF_CaseStudy2_Practise.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEBA_EF_CaseStudy2_Practise.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "CourseId")
                        .HasAnnotation("Relational:ColumnType", "int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseAbbreviation")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "CourseAbbreviation")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(10)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "CourseName")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "GetDate()");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "GetDate()");

                    b.HasKey("CourseId")
                        .HasAnnotation("Relational:Name", "PrimaryKey_CourseId");

                    b.HasIndex("CourseAbbreviation")
                        .IsUnique()
                        .HasAnnotation("Relational:Name", "Course_CourseAbbreviation_UniqueConstraint");
                });

            modelBuilder.Entity("WEBA_EF_CaseStudy2_Practise.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "StudentId")
                        .HasAnnotation("Relational:ColumnType", "int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdmissionId")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "AdmissionId")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(10)");

                    b.Property<int>("CourseId");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "GetDate()");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "Email")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "FullName")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<string>("MobileContact")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "MobileContact")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(10)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "GetDate()");

                    b.HasKey("StudentId")
                        .HasAnnotation("Relational:Name", "PrimaryKey_StudentId");

                    b.HasIndex("AdmissionId")
                        .IsUnique()
                        .HasAnnotation("Relational:Name", "Student_AdmissionId_UniqueConstraint");
                });

            modelBuilder.Entity("WEBA_EF_CaseStudy2_Practise.Models.Student", b =>
                {
                    b.HasOne("WEBA_EF_CaseStudy2_Practise.Models.Course")
                        .WithMany()
                        .HasForeignKey("CourseId");
                });
        }
    }
}
