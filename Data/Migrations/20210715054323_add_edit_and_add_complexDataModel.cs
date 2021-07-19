using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_2auth_mvc.Data.Migrations
{
    public partial class add_edit_and_add_complexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedule_Course_CourseId",
                schema: "Identity",
                table: "CourseSchedule");

          /*  migrationBuilder.DropTable(
                name: "CourseUsers",
                schema: "Identity");
*/
          /*  migrationBuilder.DropTable(
                name: "LecturerCourse",
                schema: "Identity");*/

            migrationBuilder.DropColumn(
                name: "Department",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "Identity",
                table: "CourseSchedule",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Identity",
                table: "CourseSchedule",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSchedule_CourseId",
                schema: "Identity",
                table: "CourseSchedule",
                newName: "IX_CourseSchedule_CourseID");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                schema: "Identity",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.CreateTable(
                name: "CourseAssignments",
                schema: "Identity",
                columns: table => new
                {
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignments", x => new { x.CourseID, x.LecturerID });
                    table.ForeignKey(
                        name: "FK_CourseAssignments_AspNetUsers_LecturerID",
                        column: x => x.LecturerID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignments_Course_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                schema: "Identity",
                columns: table => new
                {
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    EnrollmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.CourseID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_Enrollments_AspNetUsers_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Course_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignments_LecturerID",
                schema: "Identity",
                table: "CourseAssignments",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentID",
                schema: "Identity",
                table: "Enrollments",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedule_Course_CourseID",
                schema: "Identity",
                table: "CourseSchedule",
                column: "CourseID",
                principalSchema: "Identity",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSchedule_Course_CourseID",
                schema: "Identity",
                table: "CourseSchedule");

            migrationBuilder.DropTable(
                name: "CourseAssignments",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Enrollments",
                schema: "Identity");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                schema: "Identity",
                table: "CourseSchedule",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Identity",
                table: "CourseSchedule",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSchedule_CourseID",
                schema: "Identity",
                table: "CourseSchedule",
                newName: "IX_CourseSchedule_CourseId");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                schema: "Identity",
                table: "Course",
                newName: "CourseId");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Identity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CourseUsers",
                schema: "Identity",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUsers", x => new { x.CourseId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CourseUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUsers_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerCourse",
                schema: "Identity",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    LecturerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_LecturerCourse_AspNetUsers_LecturerId1",
                        column: x => x.LecturerId1,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseUsers_UserId",
                schema: "Identity",
                table: "CourseUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerCourse_CourseId",
                schema: "Identity",
                table: "LecturerCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerCourse_LecturerId1",
                schema: "Identity",
                table: "LecturerCourse",
                column: "LecturerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSchedule_Course_CourseId",
                schema: "Identity",
                table: "CourseSchedule",
                column: "CourseId",
                principalSchema: "Identity",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
