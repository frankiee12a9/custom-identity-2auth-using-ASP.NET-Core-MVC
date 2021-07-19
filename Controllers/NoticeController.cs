using identity_2auth_mvc.Data;
using identity_2auth_mvc.Models;
using identity_2auth_mvc.Models.Klas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace identity_2auth_mvc.Controllers
{
    public class NoticeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoticeController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> CourseNotice(int? id)
        {
            if (id == null)
                return NotFound();

            var noticeModel = await _context.Course
                    .Include(n => n.Notices)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.CourseID == id);
            if (noticeModel == null)
                return NotFound();

            return View(noticeModel);
        }

      /*  private async Task<Course> GetNoticeHelper()
        {
            var noticeModel = new Course();
            noticeModel.Notices = await _context.Notice.ToListAsync();
            return noticeModel;
        }*/

        private async Task<IActionResult> NotePartial(int id)
        {
            var noteModel = new NoticeViewModel();
            noteModel = await _context.Notice
                    .Include(n => n.Course)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.CourseId == id);
            if (noteModel == null)
                return NotFound();

            return PartialView("_TestPartial", noteModel);
        }


        public async Task<IActionResult> Index()
        {
            var courses = await _context.Course.ToListAsync();
            return View(courses);
        }

        private async Task<NoticeUploadViewModel> LoadFiles()
        {
            var viewModel = new NoticeUploadViewModel();
            viewModel.NoticesViewModel = await _context.Notice.ToListAsync();
            return viewModel;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var notice = await _context.Notice.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (notice == null) return NotFound();
            return View(notice);
        }

        /*	private async Task<string> GetCurrentLoggedInUserId()
			{
				AppUser user = await GetCurrentUserAsync ();
				return user?.Id;
			}*/

        // private async Task<AppUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);

        [HttpPost]
        public async Task<IActionResult> UploadNoticeToDB(List<IFormFile> files, string description, int courseId)
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
        public async Task<IActionResult> DownloadNoticeFromDB(int id)
        {
            var file = await _context.Notice.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file == null) return null;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }

        public async Task<IActionResult> DeleteNoticeFromDB(int id)
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
