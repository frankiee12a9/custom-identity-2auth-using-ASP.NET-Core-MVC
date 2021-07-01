using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models
{
	public class LoginViewModel
	{
		public string UserName { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name = "Remember Me")]
		public bool  RememberMe { get; set; }
		public string ReturnUrl { get; set; }
	}
}
