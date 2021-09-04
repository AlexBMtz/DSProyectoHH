using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DSProyectoHH.Web.Migrations
{
    public partial class Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassParticipations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Listening = table.Column<int>(nullable: false),
                    Reading = table.Column<int>(nullable: false),
                    SpokenInteraction = table.Column<int>(nullable: false),
                    SpokenProduction = table.Column<int>(nullable: false),
                    Fluency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassParticipations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    StartingDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OralQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Communication = table.Column<int>(nullable: false),
                    Grammar = table.Column<int>(nullable: false),
                    Vocabulary = table.Column<int>(nullable: false),
                    ConversationS = table.Column<int>(nullable: false),
                    Fluency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OralQuizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Research = table.Column<int>(nullable: false),
                    ProductQuality = table.Column<int>(nullable: false),
                    CollabWork = table.Column<int>(nullable: false),
                    Creativity = table.Column<int>(nullable: false),
                    Fluency = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    AdmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Telephone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    RFC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WrittenQuizzes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionA = table.Column<int>(nullable: false),
                    SectionB = table.Column<int>(nullable: false),
                    SectionC = table.Column<int>(nullable: false),
                    SectionD = table.Column<int>(nullable: false),
                    SectionE = table.Column<int>(nullable: false),
                    SectionF = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrittenQuizzes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WrittenQuizId = table.Column<int>(nullable: true),
                    OralQuizId = table.Column<int>(nullable: true),
                    ClassParticipationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_ClassParticipations_ClassParticipationId",
                        column: x => x.ClassParticipationId,
                        principalTable: "ClassParticipations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_OralQuizzes_OralQuizId",
                        column: x => x.OralQuizId,
                        principalTable: "OralQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_WrittenQuizzes_WrittenQuizId",
                        column: x => x.WrittenQuizId,
                        principalTable: "WrittenQuizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit1Id = table.Column<int>(nullable: true),
                    Unit2Id = table.Column<int>(nullable: true),
                    Unit3Id = table.Column<int>(nullable: true),
                    FinalProjectId = table.Column<int>(nullable: true),
                    FinalScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Projects_FinalProjectId",
                        column: x => x.FinalProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Units_Unit1Id",
                        column: x => x.Unit1Id,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Units_Unit2Id",
                        column: x => x.Unit2Id,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseDetails_Units_Unit3Id",
                        column: x => x.Unit3Id,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_FinalProjectId",
                table: "CourseDetails",
                column: "FinalProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_Unit1Id",
                table: "CourseDetails",
                column: "Unit1Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_Unit2Id",
                table: "CourseDetails",
                column: "Unit2Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDetails_Unit3Id",
                table: "CourseDetails",
                column: "Unit3Id");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ClassParticipationId",
                table: "Units",
                column: "ClassParticipationId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_OralQuizId",
                table: "Units",
                column: "OralQuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_WrittenQuizId",
                table: "Units",
                column: "WrittenQuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDetails");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CourseTypes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "ClassParticipations");

            migrationBuilder.DropTable(
                name: "OralQuizzes");

            migrationBuilder.DropTable(
                name: "WrittenQuizzes");
        }
    }
}
