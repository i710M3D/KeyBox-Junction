using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyBox.Migrations
{
    /// <inheritdoc />
    public partial class _5Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Matricule",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "Teacher",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Matricule",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
