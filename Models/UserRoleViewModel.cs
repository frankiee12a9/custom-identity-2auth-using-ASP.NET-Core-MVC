using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models
{
	public class UserRoleViewModel
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
		public virtual IEnumerable<string> Roles { get; set; }
	}
}
