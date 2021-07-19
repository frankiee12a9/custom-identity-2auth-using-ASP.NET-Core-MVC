using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_2auth_mvc.Data.Migrations
{
    public partial class add_fields_to_Course : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                schema: "Identity",
                table: "Course",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseCredit",
                schema: "Identity",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CourseDescription",
                schema: "Identity",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseType",
                schema: "Identity",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseCredit",
                schema: "Identity",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseDescription",
                schema: "Identity",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseType",
                schema: "Identity",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "CourseName",
                schema: "Identity",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
