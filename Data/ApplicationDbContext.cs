using identity_2auth_mvc.Models;
using identity_2auth_mvc.Models.Klas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace identity_2auth_mvc.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		// public DbSet<Lecturer> Lecturers { get; set; }
		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Course> Course { get; set; }
		public DbSet<NoticeViewModel> Notice { get; set; }
	/*	public DbSet<LecturerCourse> LecturerCourse { get; set; }*/
		public DbSet<CourseSchedule> CourseSchedule { get; set; }
		/*	public DbSet<CourseUser> CourseUsers { get; set; }*/
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<CourseAssignment> CourseAssignments { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			// To modify the default ugly names of the Identity Tables, add this override function,
			base.OnModelCreating(builder);
			// set schema to the database 
			builder.HasDefaultSchema("Identity");
			// all of the lines below to rename table

			builder.Entity<CourseSchedule>().HasData(
				new CourseSchedule
				{
					ID = 1,
					ClassPlace1 = "새빛관",
					ClassTime1 = "월요일 3교시",
					ClassPlace2 = "새빛관",
					ClassTime2 = "화요일 4교시",
					CourseID = 1101
				},

				new CourseSchedule
				{
					ID = 2,
					ClassPlace1 = "참빗관",
					ClassTime1 = "월요일 2교시",
					ClassPlace2 = "새빗관",
					ClassTime2 = "목요일 2교시",
					CourseID = 1102
				},

				new CourseSchedule
				{
					ID = 3,
					ClassPlace1 = "화도관",
					ClassTime1 = "수요일 2교시",
					ClassPlace2 = "화도관",
					ClassTime2 = "수요일 3교시",
					CourseID = 1103
				},

				new CourseSchedule
				{
					ID = 4,
					ClassPlace1 = "의옥관",
					ClassTime1 = "금요일 1교시",
					ClassPlace2 = "의옥관",
					ClassTime2 = "금요일 2교시",
					CourseID = 1104

				},

				new CourseSchedule
				{
					ID = 5,
					ClassPlace1 = "비마관",
					ClassTime1 = "수요일 4교시",
					ClassPlace2 = "비마관",
					ClassTime2 = "화요일 5교시",
					CourseID = 1105
				}
			);

			builder.Entity<CourseAssignment>().HasData(
				new CourseAssignment
				{
					CourseID = 1101, 
					LecturerID = "1e4cd5d1-b39e-41b0-9770-98fa6ad5120f"
				},
				new CourseAssignment
				{
					CourseID = 1102,
					LecturerID = "4874bfd3-8a49-4080-b066-867d62c240cd"
				}, new CourseAssignment
				{
					CourseID = 1103,
					LecturerID = "9bd6589b-d7f7-4ec3-9328-968149aed66d"
				}, new CourseAssignment
				{
					CourseID = 1104,
					LecturerID = "adcf9257-2707-4f4b-8de3-24626dea9748"
				}, new CourseAssignment
				{
					CourseID = 1105,
					LecturerID = "bfc28615-f88e-41ed-9350-a604fcbb163e"
				}
			);
				


			// Customize Course and AppUser relationship using FluentApi
			builder.Entity<CourseAssignment>()
				.HasKey(ca => new { ca.CourseID, ca.LecturerID });

			builder.Entity<CourseAssignment>()
				.HasOne(cu => cu.Course)
				.WithMany(c => c.CourseAssignments)
				.HasForeignKey(cu => cu.CourseID);

			builder.Entity<CourseAssignment>()
				.HasOne(cu => cu.Lecturer)
				.WithMany(u => u.CourseAssignments)
				.HasForeignKey(cu => cu.LecturerID);

			builder.Entity<Enrollment>()
				.HasKey(e => new { e.CourseID, e.StudentID });

			builder.Entity<Enrollment>()
				.HasOne(c => c.Course)
				.WithMany(e => e.Enrollments)
				.HasForeignKey(fk => fk.CourseID);

			builder.Entity<Enrollment>()
				.HasOne(s => s.Student)
				.WithMany(e => e.Enrollments)
				.HasForeignKey(fk => fk.StudentID);

			// end 

			builder.Entity<Course>().HasData(
				new Course { CourseID = 1101, CourseName = "Data Structure" },
				new Course { CourseID = 1102, CourseName = "Algorithm" },
				new Course { CourseID = 1103, CourseName = "Discrete Math" },
				new Course { CourseID = 1104, CourseName = "Database" },
				new Course { CourseID = 1105, CourseName = "English Conversation" }
			);

			builder.Entity<IdentityUser>(entity =>
			{
				entity.ToTable(name: "User");
			});

			builder.Entity<IdentityRole>(entity =>
			{
				entity.ToTable(name: "Role");
			});

			builder.Entity<IdentityUserRole<string>>(entity =>
			{
				entity.ToTable(name: "UserRoles");
			});

			builder.Entity<IdentityUserClaim<string>>(entity =>
			{
				entity.ToTable(name: "UserClaims");
			});

			builder.Entity<IdentityUserLogin<string>>(entity =>
			{
				entity.ToTable(name: "UserLogins");
			});

			builder.Entity<IdentityRoleClaim<string>>(entity =>
			{
				entity.ToTable(name: "RoleClaims");
			});

			builder.Entity<IdentityUserToken<string>>(entity =>
			{
				entity.ToTable(name: "UserTokens");
			});
		}
	}
}
