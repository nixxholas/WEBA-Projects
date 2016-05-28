using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using WEBA_EF_CaseStudy1.Models;

namespace WEBA_EF_CaseStudy1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160422160315_setupdb")]
    partial class setupdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEBA_EF_CaseStudy1.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "CompanyId")
                        .HasAnnotation("Relational:ColumnType", "int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "Address")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "CompanyName")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(100)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "GetDate()");

                    b.Property<DateTime?>("DeletedAt");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasAnnotation("Relational:ColumnName", "PostalCode")
                        .HasAnnotation("Relational:ColumnType", "VARCHAR(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:GeneratedValueSql", "GetDate()");

                    b.HasKey("CompanyId")
                        .HasAnnotation("Relational:Name", "PrimaryKey_CompanyId");

                    b.HasIndex("CompanyName")
                        .IsUnique()
                        .HasAnnotation("Relational:Name", "Company_CompanyName_UniqueConstraint");
                });
        }
    }
}
