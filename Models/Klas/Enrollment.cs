using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class Enrollment
	{
		public int EnrollmentID { get; set; }
		public string StudentID { get; set; }
		public int CourseID { get; set; }
		[ForeignKey("StudentID")]
		public virtual AppUser Student { get; set; }
		[ForeignKey("CourseID")]
		public virtual Course Course { get; set; }
	}
}
