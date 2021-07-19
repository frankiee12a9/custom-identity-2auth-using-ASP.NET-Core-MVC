using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_2auth_mvc.Data.Migrations
{
    public partial class changed_ModelsProperties_and_addSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "CourseAssignments",
                columns: new[] { "CourseID", "LecturerID" },
                values: new object[,]
                {
                    { 1101, "1e4cd5d1-b39e-41b0-9770-98fa6ad5120f" },
                    { 1102, "4874bfd3-8a49-4080-b066-867d62c240cd" },
                    { 1103, "9bd6589b-d7f7-4ec3-9328-968149aed66d" },
                    { 1104, "adcf9257-2707-4f4b-8de3-24626dea9748" },
                    { 1105, "bfc28615-f88e-41ed-9350-a604fcbb163e" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseAssignments",
                keyColumns: new[] { "CourseID", "LecturerID" },
                keyValues: new object[] { 1101, "1e4cd5d1-b39e-41b0-9770-98fa6ad5120f" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseAssignments",
                keyColumns: new[] { "CourseID", "LecturerID" },
                keyValues: new object[] { 1102, "4874bfd3-8a49-4080-b066-867d62c240cd" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseAssignments",
                keyColumns: new[] { "CourseID", "LecturerID" },
                keyValues: new object[] { 1103, "9bd6589b-d7f7-4ec3-9328-968149aed66d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseAssignments",
                keyColumns: new[] { "CourseID", "LecturerID" },
                keyValues: new object[] { 1104, "adcf9257-2707-4f4b-8de3-24626dea9748" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "CourseAssignments",
                keyColumns: new[] { "CourseID", "LecturerID" },
                keyValues: new object[] { 1105, "bfc28615-f88e-41ed-9350-a604fcbb163e" });
        }
    }
}
