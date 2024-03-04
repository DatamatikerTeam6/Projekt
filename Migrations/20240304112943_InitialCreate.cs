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
                    PositionX = table.Column<double>(type: "float", nullable: false),
                    PositionY = table.Column<double>(type: "float", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "CourseExercise",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    ExerciseID = table.Column<int>(type: "int", nullable: false),
                    PositionX = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    PositionY = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    CourseID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExercise", x => new { x.CourseID, x.ExerciseID });
                    table.ForeignKey(
                        name: "FK_CourseExercise_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseExercise_Course_CourseID1",
                        column: x => x.CourseID1,
                        principalTable: "Course",
                        principalColumn: "CourseID");
                    table.ForeignKey(
                        name: "FK_CourseExercise_Exercise_ExerciseID",
                        column: x => x.ExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseExercise_CourseID1",
                table: "CourseExercise",
                column: "CourseID1");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExercise_ExerciseID",
                table: "CourseExercise",
                column: "ExerciseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseExercise");

            migrationBuilder.DropTable(
                name: "Ruleset");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Exercise");
        }
    }
}
