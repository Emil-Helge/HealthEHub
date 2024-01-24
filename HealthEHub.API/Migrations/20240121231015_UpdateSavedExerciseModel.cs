using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthEHub.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSavedExerciseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstanceId",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstanceId",
                table: "Exercises");
        }
    }
}
