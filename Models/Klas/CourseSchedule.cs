using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class CourseSchedule
	{
		public int ID { get; set; }
		[Required]
		[Display(Name = "Class Place 1")]
		public string ClassPlace1 { get; set; }
		[Display(Name = "Class Place 2")]
		public string ClassPlace2 { get; set; }
		[Required]
		[Display(Name = "Class Time 1")]
		public string ClassTime1 { get; set; }
		[Display(Name = "Class Time 2")]
		public string ClassTime2 { get; set; }

		public int CourseID { get; set; }

		[ForeignKey("CourseID")]
		public virtual Course Course { get; set; }
	}
}
