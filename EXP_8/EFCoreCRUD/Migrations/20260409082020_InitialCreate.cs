using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreCRUD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Course", "Email", "EnrollmentDate", "Name" },
                values: new object[,]
                {
                    { 1, "Computer Science", "aayan@example.com", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aayan Mujawar" },
                    { 2, "Information Technology", "rahul@example.com", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rahul Sharma" },
                    { 3, "Electronics", "priya@example.com", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Priya Patel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
