using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyBox.Migrations
{
    /// <inheritdoc />
    public partial class _4Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Course_CoursesId",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseStudent",
                newName: "CoursesCourseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Course",
                newName: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Course_CoursesCourseId",
                table: "CourseStudent",
                column: "CoursesCourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudent_Course_CoursesCourseId",
                table: "CourseStudent");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseId",
                table: "CourseStudent",
                newName: "CoursesId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Course",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudent_Course_CoursesId",
                table: "CourseStudent",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
