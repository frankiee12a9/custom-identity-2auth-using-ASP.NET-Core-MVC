using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_2auth_mvc.Data.Migrations
{
    public partial class add_CourseScheduleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseSchedule",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassPlace1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassPlace2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassTime1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassTime2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSchedule_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedule_CourseId",
                schema: "Identity",
                table: "CourseSchedule",
                column: "CourseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSchedule",
                schema: "Identity");
        }
    }
}
