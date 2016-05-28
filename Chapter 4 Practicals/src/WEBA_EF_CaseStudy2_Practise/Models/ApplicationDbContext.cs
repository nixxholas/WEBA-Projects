using Microsoft.Data.Entity;

namespace WEBA_EF_CaseStudy2_Practise.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Frequently used command in Command Prompt:
            //dnu restore
            //dnx ef migrations add migration_file_for_setup_database
            //Reference: http://www.bricelam.net/2014/09/14/migrations-on-k.html
            optionsBuilder.UseSqlServer(@"Server=NIXH\SQLEXPRESS;Database=WEBA_EF_CaseStudyDB_2;Trusted_Connection=True;MultipleActiveResultSets=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //----------- Defining CompanyType Entity - Start --------------
            //Make the CompanyId a  Primary Key and Identity column
            modelBuilder.Entity<CompanyType>()
                       .HasKey(companyTypeClass => companyTypeClass.CompanyTypeId)
                       .HasName("PrimaryKey_CompanyTypeId");

            //Tell the modelBuilder more about the CompanyId column
            modelBuilder.Entity<CompanyType>()
             .Property(companyTypeClass => companyTypeClass.CompanyTypeId)
             .HasColumnName("CompanyTypeId")
             .HasColumnType("int")
             .UseSqlServerIdentityColumn()
             .ValueGeneratedOnAdd()
             .IsRequired();

            //Tell the modelBuilder more about the TypeName column
            modelBuilder.Entity<CompanyType>()
             .Property(companyTypeClass => companyTypeClass.TypeName)
             .HasColumnName("TypeName")
             .HasColumnType("VARCHAR(50)")
             .IsRequired();

            //Tell the modelBuilder more about the CreatedAt column
            modelBuilder.Entity<CompanyType>()
             .Property(companyTypeClass => companyTypeClass.CreatedAt)
             .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the UpdatedAt column
            modelBuilder.Entity<CompanyType>()
             .Property(companyTypeClass => companyTypeClass.UpdatedAt)
             .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the DeletedAt column
            modelBuilder.Entity<CompanyType>()
             .Property(companyTypeClass => companyTypeClass.DeletedAt)
             .IsRequired(false);

            //Enforce unique constraint on TypeName
            modelBuilder.Entity<CompanyType>()
             .HasIndex(companyTypeClass => companyTypeClass.TypeName).IsUnique()
             .HasName("CompanyType_TypeName_UniqueConstraint");
            //----------- Defining CompanyType Entity - End --------------

            //----------- Defining Company Entity - Start --------------
            //Make the CompanyId a  Primary Key and Identity column
            modelBuilder.Entity<Company>()
                    .HasKey(companyClass => companyClass.CompanyId)
                    .HasName("PrimaryKey_CompanyId");

            //Tell the modelBuilder more about the CompanyId column
            modelBuilder.Entity<Company>()
             .Property(companyClass => companyClass.CompanyId)
             .HasColumnName("CompanyId")
             .HasColumnType("int")
             .UseSqlServerIdentityColumn()
             .ValueGeneratedOnAdd()
             .IsRequired();

            //Tell the modelBuilder more about the CompanyName column
            modelBuilder.Entity<Company>()
             .Property(companyClass => companyClass.CompanyName)
             .HasColumnName("CompanyName")
             .HasColumnType("VARCHAR(100)")
             .IsRequired();

            //Tell the modelBuilder more about the PostalCode column
            modelBuilder.Entity<Company>()
             .Property(companyClass => companyClass.PostalCode)
             .HasColumnName("PostalCode")
             .HasColumnType("VARCHAR(20)")
             .IsRequired();

            //Tell the modelBuilder more about the Address column
            modelBuilder.Entity<Company>()
             .Property(companyClass => companyClass.Address)
             .HasColumnName("Address")
             .HasColumnType("VARCHAR(100)")
             .IsRequired();

            //Tell the modelBuilder more about the CreatedAt column
            modelBuilder.Entity<Company>()
             .Property(companyClass => companyClass.CreatedAt)
             .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the UpdatedAt column
            modelBuilder.Entity<Company>()
             .Property(companyClass => companyClass.UpdatedAt)
             .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the DeletedAt column
            modelBuilder.Entity<Company>()
             .Property(companyClass => companyClass.DeletedAt)
             .IsRequired(false);

            //Enforce unique constraint on Company Name
            modelBuilder.Entity<Company>()
             .HasIndex(companyClass => companyClass.CompanyName).IsUnique()
             .HasName("Company_CompanyName_UniqueConstraint");

            //----------- Defining Company Entity - End --------------

            //----------- Defining Course Entity - Start --------------
            //Make the CourseId a  Primary Key and 
            modelBuilder.Entity<Course>()
            .HasKey(courseClass => courseClass.CourseId)
            .HasName("PrimaryKey_CourseId");
            //Defining general properties of CourseId
            modelBuilder.Entity<Course>()
            .Property(courseClass => courseClass.CourseId)
            .HasColumnName("CourseId")
            .HasColumnType("int")
            .UseSqlServerIdentityColumn()
            .ValueGeneratedOnAdd()
            .IsRequired();
            //Defining general properties of CourseName
            modelBuilder.Entity<Course>()
            .Property(courseClass => courseClass.CourseName)
            .HasColumnName("CourseName")
            .HasColumnType("VARCHAR(100)")
            .IsRequired();

            //Describe CourseAbbreviation behavior
            modelBuilder.Entity<Course>()
            .Property(courseClass => courseClass.CourseAbbreviation)
            .HasColumnName("CourseAbbreviation")
            .HasColumnType("VARCHAR(10)")
            .IsRequired();
            //Describe CreatedAt behavior
            modelBuilder.Entity<Course>()
            .Property(courseClass => courseClass.CreatedAt)
            .HasDefaultValueSql("GetDate()");
            //Describe UpdatedAt behavior
            modelBuilder.Entity<Course>()
            .Property(courseClass => courseClass.UpdatedAt)
            .HasDefaultValueSql("GetDate()");
            //Describe DeletedAt behavior
            modelBuilder.Entity<Course>()
            .Property(courseClass => courseClass.DeletedAt)
            .IsRequired(false);

            //Enforce unique constraint on Course Abbreviation
            modelBuilder.Entity<Course>()
             .HasIndex(courseClass => courseClass.CourseAbbreviation).IsUnique()
             .HasName("Course_CourseAbbreviation_UniqueConstraint");
            //----------- Defining Course Entity - End --------------

            //----------- Defining Student Entity - Start --------------
            //Make the StudentId a  Primary Key and Identity column
            modelBuilder.Entity<Student>()
             .HasKey(studentClass => studentClass.StudentId)
             .HasName("PrimaryKey_StudentId");

            modelBuilder.Entity<Student>()
            .Property(studentClass => studentClass.StudentId)
            .HasColumnName("StudentId")
            .HasColumnType("int")
            .UseSqlServerIdentityColumn()
            .ValueGeneratedOnAdd()
            .IsRequired();
            modelBuilder.Entity<Student>()
             .Property(studentClass => studentClass.AdmissionId)
             .HasColumnName("AdmissionId")
             .HasColumnType("VARCHAR(10)")
             .IsRequired(true);
            modelBuilder.Entity<Student>()
             .Property(studentClass => studentClass.MobileContact)
             .HasColumnName("MobileContact")
             .HasColumnType("VARCHAR(10)")
             .IsRequired(true);
            modelBuilder.Entity<Student>()
             .Property(studentClass => studentClass.Email)
             .HasColumnName("Email")
             .HasColumnType("VARCHAR(50)")
             .IsRequired(true);
            modelBuilder.Entity<Student>()
             .Property(studentClass => studentClass.FullName)
             .HasColumnName("FullName")
             .HasColumnType("VARCHAR(100)")
             .IsRequired(true);
            modelBuilder.Entity<Student>()
                .Property(studentClass => studentClass.CreatedAt)
                 .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Student>()
                .Property(input => input.UpdatedAt)
                 .HasDefaultValueSql("GetDate()");
            modelBuilder.Entity<Student>()
                  .Property(studentClass => studentClass.DeletedAt)
                   .IsRequired(false);
            //Enforce unique constraint on AdmissionId
            modelBuilder.Entity<Student>()
             .HasIndex(studentClass => studentClass.AdmissionId).IsUnique()
             .HasName("Student_AdmissionId_UniqueConstraint");
            //----------- Defining Student Entity - End --------------

            //Setup Many to One relationship between Student and Course
            modelBuilder.Entity<Student>()
            .HasOne(studentClass => studentClass.Course)
            .WithMany(courseClass => courseClass.Students)
            .HasForeignKey(studentClass => studentClass.CourseId);
            //Setup Many-to-One relationship between Company and CompanyType
            modelBuilder.Entity<Company>()
            .HasOne(companyClass => companyClass.CompanyType)
            .WithMany(companyTypeClass => companyTypeClass.Companies)
            .HasForeignKey(companyClass => companyClass.CompanyTypeId);



            base.OnModelCreating(modelBuilder);

        }//End of onModelCreating() method
    }//End of ApplicationDbContext class definition
}//End of namespace definition
