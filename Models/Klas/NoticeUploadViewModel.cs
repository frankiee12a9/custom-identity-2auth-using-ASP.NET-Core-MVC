using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class NoticeUploadViewModel 
	{
		public AppUser AppUser { get; set; }
		public virtual ICollection<NoticeViewModel> NoticesViewModel { get; set; }
	}
}
