using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_2auth_mvc.Data.Migrations
{
    public partial class added_seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "CourseSchedule",
                columns: new[] { "ID", "ClassPlace1", "ClassPlace2", "ClassTime1", "ClassTime2", "CourseID" },
                values: new object[,]
                {
                    { 1, "새빛관", "새빛관", "월요일 3교시", "화요일 4교시", 1101 },
                    { 2, "참빗관", "새빗관", "월요일 2교시", "목요일 2교시", 1102 },
                    { 3, "화도관", "화도관", "수요일 2교시", "수요일 3교시", 1103 },
                    { 4, "의옥관", "의옥관", "금요일 1교시", "금요일 2교시", 1104 },
                    { 5, "비마관", "비마관", "수요일 4교시", "화요일 5교시", 1105 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseSchedule",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseSchedule",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseSchedule",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseSchedule",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseSchedule",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
