using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_2auth_mvc.Data.Migrations
{
    public partial class add_noticeViewModel_to_course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Course",
                columns: new[] { "CourseId", "CourseName" },
                values: new object[,]
                {
                    { 1101, "Data Structure" },
                    { 1102, "Algorithm" },
                    { 1103, "Discrete Math" },
                    { 1104, "Database" },
                    { 1105, "English Conversation" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Course",
                keyColumn: "CourseId",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Course",
                keyColumn: "CourseId",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Course",
                keyColumn: "CourseId",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Course",
                keyColumn: "CourseId",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Course",
                keyColumn: "CourseId",
                keyValue: 1105);
        }
    }
}
