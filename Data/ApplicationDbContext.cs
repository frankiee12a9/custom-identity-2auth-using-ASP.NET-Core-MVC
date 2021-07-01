using identity_2auth_mvc.Models;
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

		public DbSet<Lecturer> Lecturers { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			// To modify the default ugly names of the Identity Tables, add this override function,
			base.OnModelCreating(builder);
			// set schema to the database 
			builder.HasDefaultSchema("Identity");
			// all of the lines below to rename table 
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
