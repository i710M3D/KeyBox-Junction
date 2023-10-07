using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyBox.Migrations
{
    /// <inheritdoc />
    public partial class initiaCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Matricule = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    role = table.Column<string>(type: "TEXT", nullable: false),
                    IsSport = table.Column<bool>(type: "INTEGER", nullable: false),
                    WeeklyStudyHours = table.Column<int>(type: "INTEGER", nullable: false),
                    IsTakingNotes = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAttending = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsArrived = table.Column<bool>(type: "INTEGER", nullable: false),
                    AdditionalWork = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
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
