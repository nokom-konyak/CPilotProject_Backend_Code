using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pilot_Project.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMasterData",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileNo = table.Column<long>(type: "bigint", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMasterData", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Course_Registration",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_Registration", x => new { x.EmployeeId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Course_Registration_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_Registration_EmployeeMasterData_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeMasterData",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Registration_CourseId",
                table: "Course_Registration",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMasterData_mobileNo",
                table: "EmployeeMasterData",
                column: "mobileNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course_Registration");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "EmployeeMasterData");
        }
    }
}
