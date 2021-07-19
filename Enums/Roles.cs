using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Enums
{
	public enum Roles
	{
		Admin,
		Professor,
		[Display(Name = "Teaching Assistant")]
		TA,
		Student,
		Basic
	}
}
