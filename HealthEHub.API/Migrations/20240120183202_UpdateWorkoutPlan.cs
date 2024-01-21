using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthEHub.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWorkoutPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "BodyPart",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "GifUrl",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "SecondaryMuscles",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "Target",
                table: "Exercises",
                newName: "ExerciseId");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutPlanId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SavedExerciseId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "SavedExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "SavedExerciseId",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "ExerciseId",
                table: "Exercises",
                newName: "Target");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutPlanId",
                table: "Exercises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BodyPart",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GifUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryMuscles",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");
        }
    }
}
