using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace identity_2auth_mvc.Data.Migrations
{
    public partial class add_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Role_RoleId",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "Identity",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "AspNetUserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "AspNetUserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "AspNetUserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "AspNetUserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "AspNetRoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "AspNetRoles",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                schema: "Identity",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                schema: "Identity",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "Identity",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "Identity",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "LecturerCourse",
                schema: "Identity",
                columns: table => new
                {
                    LecturerId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Notice",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notice_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Identity",
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Notice_CourseId",
                schema: "Identity",
                table: "Notice",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LecturerCourse",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Notice",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                schema: "Identity",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                schema: "Identity",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                schema: "Identity",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                schema: "Identity",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                schema: "Identity",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                schema: "Identity",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Identity",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                schema: "Identity",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                schema: "Identity",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "Identity",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                schema: "Identity",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Role_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
