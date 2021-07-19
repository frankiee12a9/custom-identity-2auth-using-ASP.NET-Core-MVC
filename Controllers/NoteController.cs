using identity_2auth_mvc.Data;
using identity_2auth_mvc.Models.Klas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Controllers
{
	public class NoteController : Controller
	{
		private readonly ApplicationDbContext _context;

		public NoteController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			List<SelectListItem> listItem = new List<SelectListItem>();
			var courses = await _context.Course.ToListAsync();
			foreach (var course in courses)
			{
				listItem.Add(new SelectListItem { Text = course.CourseName, Value = course.CourseID.ToString() });
			}

			ViewBag.CourseList = listItem;
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetNoteById(int id)
		{
			var noteModel = await _context.Course
					.Include(n => n.Notices)
						.AsNoTracking()
						.FirstOrDefaultAsync(m => m.CourseID == id);

			if (noteModel == null)
				return Json(new { data = NotFound(), message = "Error while retrieving data." });

			return Json(noteModel);
		}

	
		public async Task<IActionResult> Detail(int? id)
		{	
			var notice = await _context.Notice.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (notice == null) return NotFound();
			return View(notice);
		}


		[HttpPost]
		public async Task<IActionResult> UploadNoteToDB(List<IFormFile> files, string description, int courseId)
		{
			foreach (var file in files)
			{
				var fileName = Path.GetFileNameWithoutExtension(file.FileName);
				var extension = Path.GetExtension(file.FileName);
				var noticeModel = new NoticeViewModel
				{
					CourseId = courseId,
					CreatedOn = DateTime.Now,
					FileType = file.ContentType,
					Extension = extension,
					Name = fileName,
					Description = description
				};

				using (var dataStream = new MemoryStream())
				{
					await file.CopyToAsync(dataStream);
					noticeModel.Data = dataStream.ToArray();
				}

				_context.Notice.Add(noticeModel);
				await _context.SaveChangesAsync();
			}

			TempData["Message"] = "File successfully updated to Database.";
			return RedirectToAction("Index");
		}

		// download file that attached in notice 
		public async Task<IActionResult> DownloadNoteFromDB(int id)
		{
			var file = await _context.Notice.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (file == null) return null;
			return File(file.Data, file.FileType, file.Name + file.Extension);
		}

		public async Task<IActionResult> DeleteNoteFromDB(int id)
		{
			var file = await _context.Notice.Where(x => x.Id == id).FirstOrDefaultAsync();
			if (file == null) return null;
			_context.Notice.Remove(file);
			await _context.SaveChangesAsync();
			TempData["Message"] = $"Removed {file.Name + file.Extension} successfully from database.";
			return RedirectToAction("Index");
		}
	}
}
