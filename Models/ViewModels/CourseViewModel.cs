using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity_2auth_mvc.Models.Klas;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace identity_2auth_mvc.Models.ViewModels
{
	public class CourseViewModel
	{
		public Course Course { get; set; }
		// for students
		public IList<SelectListItem> ProfessorList { get; set; }
		public IList<SelectListItem> TAList { get; set; }
		public IList<SelectListItem> StudentList { get; set; }

		public IList<SelectListItem> CourseTypeList { get; set; } 
		public IEnumerable<AppUser> AppUsers { get; set; }
		public CourseAssignment CourseAssignment { get; set; }
		public IEnumerable<Enrollment> Enrollments { get; set; }
	}
}
