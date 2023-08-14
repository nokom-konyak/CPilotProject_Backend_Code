using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pilot_Project.Migrations
{
    /// <inheritdoc />
    public partial class miggg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Registration_Course_CourseId",
                table: "Course_Registration");

            migrationBuilder.DropIndex(
                name: "IX_Course_Registration_CourseId",
                table: "Course_Registration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Course_Registration_CourseId",
                table: "Course_Registration",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Registration_Course_CourseId",
                table: "Course_Registration",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
