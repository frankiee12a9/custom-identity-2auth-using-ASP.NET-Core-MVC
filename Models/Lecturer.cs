using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models
{
	public class Lecturer: AppUser
	{
		public string Department { get; set; }
	}
}
