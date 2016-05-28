using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.Entity;
using WEBA_EF_CaseStudy3_Practise.Models;

namespace WEBA_EF_CaseStudy3_Practise.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Role> Roles { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(@"Server=NIXH\SQLEXPRESS;Database=WEBA_EF_CaseStudyDB_3;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //*******Uncomment the code here (Line 34 to line 209) ******/
            //               after you have finished defining the 5 classes                /
            //******************************************************/
           
            //----------- Defining Role Entity - Start --------------
            //Make the RoleId a  Primary Key and Identity column
            modelBuilder.Entity<Role>()
                .HasKey(roleClass => roleClass.RoleId)
                .HasName("PrimaryKey_RoleId");

            //Tell the modelBuilder more about the RoleId column
            modelBuilder.Entity<Role>()
                .Property(roleClass => roleClass.RoleId)
                .HasColumnName("RoleId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            //Tell the modelBuilder more about the RoleName column
            modelBuilder.Entity<Role>()
                .Property(roleClass => roleClass.RoleName)
                .HasColumnName("RoleName")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            //Tell the modelBuilder more about the CreatedAt column
            modelBuilder.Entity<Role>()
                .Property(roleClass => roleClass.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the UpdatedAt column
            modelBuilder.Entity<Role>()
                .Property(roleClass => roleClass.UpdatedAt)
                .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the DeletedAt column
            modelBuilder.Entity<Role>()
                .Property(roleClass => roleClass.DeletedAt)
                .IsRequired(false);
            //--------------- End of Role Entity Definition ------------------------

            //----------- Defining Project Entity - Start --------------
            //Make the ProjectId a  Primary Key and Identity column
            modelBuilder.Entity<Project>()
                .HasKey(projectClass => projectClass.ProjectId)
                .HasName("PrimaryKey_ProjectId");

            //Tell the modelBuilder more about the ProjectId column
            modelBuilder.Entity<Project>()
                .Property(projectClass => projectClass.ProjectId)
                .HasColumnName("ProjectId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();

            //Tell the modelBuilder more about the ProjectName column
            modelBuilder.Entity<Project>()
                .Property(projectClass => projectClass.ProjectName)
                .HasColumnName("ProjectName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            //Tell the modelBuilder more about the ProjectStartDate column
            modelBuilder.Entity<Project>()
                .Property(projectClass => projectClass.ProjectStartDate)
                .HasColumnName("ProjectStartDate")
                .IsRequired();

            //Tell the modelBuilder more about the ProjectEndDate column
            modelBuilder.Entity<Project>()
                .Property(projectClass => projectClass.ProjectEndDate)
                .HasColumnName("ProjectEndDate")
                .IsRequired();

            //Tell the modelBuilder more about the CreatedAt column
            modelBuilder.Entity<Project>()
                .Property(projectClass => projectClass.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the UpdatedAt column
            modelBuilder.Entity<Project>()
                .Property(projectClass => projectClass.UpdatedAt)
                .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the DeletedAt column
            modelBuilder.Entity<Project>()
                .Property(projectClass => projectClass.DeletedAt)
                .IsRequired(false);
            //--------------- End of Project Entity Definition ------------------------

            //----------- Defining ProjectType Entity - Start               --------------
            //Make the ProjectTypeId a  Primary Key and Identity column
            modelBuilder.Entity<ProjectType>()
                                                        .HasKey(projectTypeClass => projectTypeClass.ProjectTypeId)
                                                        .HasName("PrimaryKey_ProjectTypeId");
            //Tell the modelBuilder more about the ProjectTypeId column
            modelBuilder.Entity<ProjectType>()
                .Property(projectTypeClass => projectTypeClass.ProjectTypeId)
                .HasColumnName("ProjectTypeId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();
            //Tell the modelBuilder more about the ProjectTypeName column
            modelBuilder.Entity<ProjectType>()
                .Property(projectTypeClass => projectTypeClass.ProjectTypeName)
                .HasColumnName("ProjectTypeName")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            //Tell the modelBuilder more about the CreatedAt column
            modelBuilder.Entity<ProjectType>()
                .Property(projectTypeClass => projectTypeClass.CreatedAt)
                .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the UpdatedAt column
            modelBuilder.Entity<ProjectType>()
                .Property(projectTypeClass => projectTypeClass.UpdatedAt)
                .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the DeletedAt column
            modelBuilder.Entity<ProjectType>()
                .Property(projectTypeClass => projectTypeClass.DeletedAt)
                .IsRequired(false);
            //----------- End of ProjectType Entity Definition ------------------------

            //----------- Defining Employee Entity - Start                      --------------
            //Make the EmployeeId a  Primary Key and Identity column
            modelBuilder.Entity<Employee>()
                .HasKey(employeeClass => employeeClass.EmployeeId)
                .HasName("PrimaryKey_EmployeeId");
            //Tell the modelBuilder more about the EmployeeId column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.EmployeeId)
                .HasColumnName("EmployeeId")
                .HasColumnType("int")
                .UseSqlServerIdentityColumn()
                .ValueGeneratedOnAdd()
                .IsRequired();
            //Tell the modelBuilder more about the FullName column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.FullName)
                .HasColumnName("FullName")
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            //Tell the modelBuilder more about the StaffId column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.StaffId)
                .HasColumnName("StaffId")
                .HasColumnType("VARCHAR(10)")
                .IsRequired();
            //Tell the modelBuilder more about the Email column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.Email)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(50)")
                .IsRequired();
            //Tell the modelBuilder more about the MobileContact column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.MobileContact)
                .HasColumnName("MobileContact")
                .HasColumnType("VARCHAR(20)")
                .IsRequired();
            //Tell the modelBuilder more about the CreatedAt column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.CreatedAt)
                .HasDefaultValueSql("GetDate()");
            //Tell the modelBuilder more about the UpdatedAt column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.UpdatedAt)
                .HasDefaultValueSql("GetDate()");
            //Tell the modelBuilder more about the DeletedAt column
            modelBuilder.Entity<Employee>()
                .Property(employeeClass => employeeClass.DeletedAt)
                .IsRequired(false);
            //--------------- End of Employee Entity Definition ------------------------
         
   

            //--------------- Start of Relationship Definition ----------------------------
           
                                 //[MISSING RELATIONSHIP CODE]



            //--------------- End of Relationship Definition ----------------------------


            base.OnModelCreating(modelBuilder);
            //Added this command after checking Rowan Miller's project
            //Rowan Miller plays major role behind Entity Framework design



        }//End of onModelCreating() method
    }//End of ApplicationDbContext class definition
}//End of namespace definition
