using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class NoticeViewModel: NoticeModel
	{
		public Byte[] Data { get; set; }
		public int CourseId { get; set; }
		public virtual Course Course { get; set; }
	}
}
