using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class CourseAssignment
	{
		public string LecturerID { get; set; }
		public int CourseID { get; set; }
		[ForeignKey("CourseID")]
		public virtual Course Course { get; set; }
		[ForeignKey("LecturerID")]
		public virtual AppUser Lecturer { get; set; }
	}
}
