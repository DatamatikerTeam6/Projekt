using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HundeProjekt.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovementEnumID = table.Column<int>(type: "int", nullable: false),
                    Sideshift = table.Column<bool>(type: "bit", nullable: false),
                    IllustrationPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassEnumID = table.Column<int>(type: "int", nullable: false),
                    SignNumber = table.Column<int>(type: "int", nullable: false),
                    PositionX = table.Column<int>(type: "int", nullable: false),
                    PositionY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseID);
                });

            migrationBuilder.CreateTable(
                name: "Ruleset",
                columns: table => new
                {
                    RulesetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RulesetClass = table.Column<int>(type: "int", nullable: false),
                    NumberOfExercises = table.Column<int>(type: "int", nullable: false),
                    NumberOfBeginner = table.Column<int>(type: "int", nullable: false),
                    NumberOfIntermediate = table.Column<int>(type: "int", nullable: false),
                    NumberOfExpert = table.Column<int>(type: "int", nullable: false),
                    NumberOfChampion = table.Column<int>(type: "int", nullable: false),
                    NumberOfConeExercises = table.Column<int>(type: "int", nullable: false),
                    NumberOfStationary = table.Column<int>(type: "int", nullable: false),
                    NumberOfRightActs = table.Column<int>(type: "int", nullable: false),
                    NumberOfReverseExercises = table.Column<int>(type: "int", nullable: false),
                    NumberOfJumpExercises = table.Column<int>(type: "int", nullable: false),
                    NumberOfSingleJumpExercises = table.Column<int>(type: "int", nullable: false),
                    NumberOfDoubleJumpExercises = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruleset", x => x.RulesetID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Ruleset");
        }
    }
}
