using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthEHub.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExerciseModelV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeekNumber",
                table: "Exercises",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "WeekNumber",
                table: "Exercises");
        }
    }
}
