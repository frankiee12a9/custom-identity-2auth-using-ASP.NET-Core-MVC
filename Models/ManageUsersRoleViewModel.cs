using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models
{
	public class ManageUsersRoleViewModel
	{ 
		public string RoleId { get; set; }
		public string RoleName { get; set; }
		public bool IsSelectedRole { get; set; }
	}
}
