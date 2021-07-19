using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Utilities
{
	public static class StaticDetails
	{
		public const string CourseTypeRequried = "Required";
		public const string CourseTypeElective = "Elective";
		public static readonly IList<string> CourseTypes = new ReadOnlyCollection<string>(new List<string>
		{
			"Required", "Elective"
		});

		public static readonly IList<string> LecturerTypes = new ReadOnlyCollection<string>(new List<string>
		{
			"Professor", "Teaching assistant"
		});
		public const int CourseCredit1 = 1;
		public const int CourseCredit2 = 2;
		public const int CourseCredit3 = 3;
	}
}
