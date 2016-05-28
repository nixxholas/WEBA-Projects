using Microsoft.Data.Entity;

namespace WEBA_EF_CaseStudy1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Frequently used command in Command Prompt:
            //dnu restore https://github.com/aspnet/Home/wiki/DNX-utility
            //dnx ef migrations add migration_file_for_setup_database
            //Reference: http://www.bricelam.net/2014/09/14/migrations-on-k.html
            optionsBuilder.UseSqlServer(@"Server=NIXH\SQLEXPRESS;Database=WEBA_EF_CaseStudyDB_1;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //----------- Defining Company Entity - Start --------------
            //Make the CompanyId a  Primary Key and Identity column
            modelBuilder.Entity<Company>()
                       .HasKey(input => input.CompanyId)
                       .HasName("PrimaryKey_CompanyId");

            //Tell the modelBuilder more about the CompanyId column
            modelBuilder.Entity<Company>()
             .Property(input => input.CompanyId)
             .HasColumnName("CompanyId")
             .HasColumnType("int")
             .UseSqlServerIdentityColumn()
             .ValueGeneratedOnAdd()
             .IsRequired();

            //Tell the modelBuilder more about the CompanyName column
            modelBuilder.Entity<Company>()
             .Property(input => input.CompanyName)
             .HasColumnName("CompanyName")
             .HasColumnType("VARCHAR(100)")
             .IsRequired();

            //Tell the modelBuilder more about the PostalCode column
            modelBuilder.Entity<Company>()
             .Property(input => input.PostalCode)
             .HasColumnName("PostalCode")
             .HasColumnType("VARCHAR(20)")
             .IsRequired();

            //Tell the modelBuilder more about the Address column
            modelBuilder.Entity<Company>()
             .Property(input => input.Address)
             .HasColumnName("Address")
             .HasColumnType("VARCHAR(100)")
             .IsRequired();

            //Tell the modelBuilder more about the CreatedAt column
            modelBuilder.Entity<Company>()
             .Property(input => input.CreatedAt)
             .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the UpdatedAt column
            modelBuilder.Entity<Company>()
             .Property(input => input.UpdatedAt)
             .HasDefaultValueSql("GetDate()");

            //Tell the modelBuilder more about the DeletedAt column
            modelBuilder.Entity<Company>()
             .Property(input => input.DeletedAt)
             .IsRequired(false);

            //Enforce unique constraint on Company Name
            modelBuilder.Entity<Company>()
             .HasIndex(input => input.CompanyName).IsUnique()
             .HasName("Company_CompanyName_UniqueConstraint");

            //----------- Defining Company Entity - End --------------


            base.OnModelCreating(modelBuilder);
            //Added this command after checking Rowan Miller's project
            //Rowan Miller plays major role behind Entity Framework design



        }//End of onModelCreating() method
    }//End of ApplicationDbContext class definition
}//End of namespace definition
