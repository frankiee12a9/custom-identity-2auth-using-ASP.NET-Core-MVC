using identity_2auth_mvc.Models.Klas;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models
{
	public class AppUser : IdentityUser
	{
		[Display(Name = "First Name")]
		public string FirstName { get; set; }
		[Display(Name = "Last Name")]
		public string LastName { get; set; }
		// for Lecturer
		public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
		// for students
		public virtual ICollection<Enrollment> Enrollments { get; set; }
		/*	public virtual IEnumerable<CourseUser> CourseUsers { get; set; }*/
	}
}
