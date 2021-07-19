using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class Course
	{
		public int CourseID { get; set; }
		[Required]
		[Display(Name = "Course Name")]
		public string CourseName { get; set; }
		[Display(Name = "Course Type")]
		public string CourseType { get; set; }
		[Display(Name = "Course Description")]
		public string  CourseDescription { get; set; }

		[Required]
		[Display(Name = "Course Credit")]
		public int CourseCredit { get; set; }
		public virtual ICollection<NoticeViewModel> Notices { get; set; }
		public virtual CourseSchedule CourseSchedule { get; set; }
		/*	public virtual ICollection<CourseUser> CourseUsers { get; set; }*/

		// join with Lecturer
		public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
		// join with Students
		public virtual ICollection<Enrollment> Enrollments { get; set; }
	}
}
