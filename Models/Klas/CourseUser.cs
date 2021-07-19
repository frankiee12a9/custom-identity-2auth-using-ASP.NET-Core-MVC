using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class CourseUser
	{
		public int CourseId { get; set; }
		public virtual Course Course { get; set; }
		public string UserId { get; set; }
		public virtual AppUser AppUser { get; set; }
	}	
}

