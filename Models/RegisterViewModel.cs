using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models
{
	public class RegisterViewModel
	{
		[Required, MaxLength(100)]
		public string UserName { get; set; }
		[Required, DataType(DataType.Password)]
		public string Password { get; set; }
		[DataType(DataType.Password), Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
	}
}
