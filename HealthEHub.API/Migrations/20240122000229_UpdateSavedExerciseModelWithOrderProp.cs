﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthEHub.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSavedExerciseModelWithOrderProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Exercises");
        }
    }
}
