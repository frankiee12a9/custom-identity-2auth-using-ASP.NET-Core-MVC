using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Models.Klas
{
	public class NoticeModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Display(Name = "File Type")]
		public string FileType { get; set; }
		[Display(Name = "File Extension")]
		public string Extension { get; set; }
		public string Description { get; set; }
		[Display(Name = "Uploaded By")]
		public string UploadedBy { get; set; }
		[DataType(DataType.Date), Display(Name = "Time Stamp"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? CreatedOn { get; set; }
	}
}
