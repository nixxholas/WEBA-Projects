using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WEBA_EF_CaseStudy1.Migrations
{
    public partial class setupdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CompanyName = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()"),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    PostalCode = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GetDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CompanyId", x => x.CompanyId);
                });
            migrationBuilder.CreateIndex(
                name: "Company_CompanyName_UniqueConstraint",
                table: "Company",
                column: "CompanyName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Company");
        }
    }
}
