using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChopNShop.Migrations
{
    /// <inheritdoc />
    public partial class AddStepsAndPrepTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "PrepTime",
                table: "Recipe",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StepsRaw",
                table: "Recipe",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrepTime",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "StepsRaw",
                table: "Recipe");
        }
    }
}
