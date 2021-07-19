using identity_2auth_mvc.Data;
using identity_2auth_mvc.Models;
using identity_2auth_mvc.Models.Klas;
using identity_2auth_mvc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity_2auth_mvc.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using identity_2auth_mvc.Utilities;

namespace identity_2auth_mvc.Controllers
{
	public class CourseManageController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<AppUser> _userManager;
		
		[BindProperty(SupportsGet = true)]
		public CourseViewModel CourseVM { get; set; }

		public CourseManageController(ApplicationDbContext db, UserManager<AppUser> userManager)
		{
			_db = db;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var courses = await _db.Course.ToListAsync();
			return View(courses);
		}


		public async Task<IActionResult> Detail(int? id)
		{
			if (id == null)
				return NotFound();

			var course = await _db.Course.Where(c => c.CourseID == id).FirstOrDefaultAsync();
			if (course == null)
				return NotFound();

			return View(course);
		}


		// AppUsers are Student and Lecturer
		[HttpGet]
		public async Task<IActionResult> Upsert(int? id)
		{
			List<SelectListItem> professorsList = new List<SelectListItem>();
			List<SelectListItem> teachingAssList = new List<SelectListItem>();
			CourseVM.AppUsers = _db.AppUsers.ToList();
			foreach (var lecturer in CourseVM.AppUsers)
			{
				if (await _userManager.IsInRoleAsync(lecturer, Enums.Roles.Professor.ToString()))
				{
					professorsList.Add(
						new SelectListItem { Text = lecturer.UserName, Value = lecturer.Id.ToString() }
						);
				}
				else if (await _userManager.IsInRoleAsync(lecturer, Enums.Roles.TA.ToString()))
				{
					teachingAssList.Add(
						new SelectListItem { Text = lecturer.UserName, Value = lecturer.Id.ToString() }
					);
				}
			}

			/*	ViewBag.ProfessorDropdownList = professorsList;
				ViewBag.TeachingAssistantDropdownList = teachingAssList;
	*/
			CourseVM = new CourseViewModel()
			{
				Course = new Course(),
				Enrollments = new List<Enrollment>(),
				CourseAssignment = new CourseAssignment(),
				ProfessorList = professorsList,
				TAList = teachingAssList,
				CourseTypeList = GetCourseTypeDropdownList()
			};

			if (id != null)
			{
				CourseVM.Course = await _db.Course.Where(c => c.CourseID == id)
					.Include(c => c.CourseSchedule).Where(c => c.CourseID == id)
					.Include(ce => ce.CourseAssignments)
						.ThenInclude(l => l.Lecturer)
					.Include(e => e.Enrollments)
						.ThenInclude(s => s.Student)
					.AsNoTracking()
					.FirstOrDefaultAsync();
			}

			return View(CourseVM);
		}


	/*	private async void PopulateLecturerList()
		{
		
			List<SelectListItem> professorsList = new List<SelectListItem>();
			List<SelectListItem> teachingAssList = new List<SelectListItem>();
			CourseVM.AppUsers = _db.AppUsers.ToList();
			foreach (var lecturer in CourseVM.AppUsers)
			{
				if (await _userManager.IsInRoleAsync(lecturer, Enums.Roles.Professor.ToString()))
				{
					professorsList.Add(
						new SelectListItem { Text = lecturer.UserName, Value = lecturer.Id.ToString() }
						);
				}
				else if(await _userManager.IsInRoleAsync(lecturer, Enums.Roles.TA.ToString()))
				{
					teachingAssList.Add(
						new SelectListItem { Text = lecturer.UserName, Value = lecturer.Id.ToString() }
					);
				}
			}

			*//*ViewBag.ProfessorDropdownList = professorsList;
			ViewBag.TeachingAssistantDropdownList = teachingAssList;*//*
		}*/

	
	

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Upsert()
		{
			if (ModelState.IsValid)
			{
				if (CourseVM.Course.CourseID == 0)
				{
				/*	CourseVM.Course = new Course()
					{
						CourseID = CourseVM.Course.CourseID,
						CourseCredit = CourseVM.Course.CourseCredit,
						CourseName = CourseVM.Course.CourseName,
						CourseType = CourseVM.Course.CourseType,
						CourseDescription = CourseVM.Course.CourseDescription,
						CourseSchedule = new CourseSchedule()
						{
							ClassPlace1 = CourseVM.Course.CourseSchedule.ClassPlace1,
							ClassTime1 = CourseVM.Course.CourseSchedule.ClassTime1,
							ClassPlace2 = CourseVM.Course.CourseSchedule.ClassPlace2,
							ClassTime2 = CourseVM.Course.CourseSchedule.ClassTime2
						}
					};
*//*
					if (CourseVM.Course == null)
						return NotFound();*/

					try
					{
						await _db.Course.AddAsync(CourseVM.Course);
						await _db.CourseAssignments.AddAsync(CourseVM.CourseAssignment);
						_db.SaveChanges();
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("Unable to save changes. " +
								"Try again, and if the problem persists, " +
								"see your system administrator.", ex.Message);
					}
				}
				else
				{
					var courseModel = await _db.Course.Where(c => c.CourseID == CourseVM.Course.CourseID)
						.FirstOrDefaultAsync();
					var courseAssignment = await _db.CourseAssignments.Where(c => c.CourseID == CourseVM.Course.CourseID)
						.FirstOrDefaultAsync();

					if (courseModel == null)
						return NotFound();

					if (await TryUpdateModelAsync<Course>(courseModel,"",
						c => c.CourseName,
						c => c.CourseType,
						c => c.CourseCredit,
						c => c.CourseDescription,
						c => c.CourseSchedule.ClassTime1,
						c => c.CourseSchedule.ClassPlace2,
						c => c.CourseSchedule.ClassTime2,
						c => c.CourseSchedule.ClassPlace2
					) && (await TryUpdateModelAsync<CourseAssignment>(courseAssignment, "",
						cs => cs.Course.CourseName,
						cs => cs.Lecturer.UserName)))
					{
						try
						{
							_db.Course.Update(CourseVM.Course);
							_db.CourseAssignments.Update(CourseVM.CourseAssignment);
							await _db.SaveChangesAsync();
							return RedirectToAction(nameof(Index));
						}
						catch (DbUpdateException)
						{
							ModelState.AddModelError("", "Unable to save changes. " +
							"Try again, and if the problem persists, " +
							"see your system administrator.");
						}
					}
				}

				// await _db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			else
			{
				Console.WriteLine($"{CourseVM.Course}");
			}

			return View(CourseVM);
		}

		/*	[HttpPost]
			[ValidateAntiForgeryToken]
			public async Task<IActionResult> Upsert(int? id)
			{
				var viewModel = new CourseViewModel();
				if (ModelState.IsValid)
				{
					// create newly
					if (viewModel.Course.CourseID != 0)
					{


					}
					else
					{
						// update
						viewModel.Course = await _db.Course.Where(c => c.CourseID == id)
							.Include(c => c.CourseSchedule).Where(c => c.CourseID == id)
							.Include(ce => ce.CourseAssignments)
								.ThenInclude(l => l.Lecturer)
							.Include(e => e.Enrollments)
								.ThenInclude(s => s.Student)
							.AsNoTracking()
							.FirstOrDefaultAsync();

						if (viewModel.Course == null)
							return NotFound();

						if (await TryUpdateModelAsync<Course>(viewModel.Course,"",
							c => c.CourseName,
							c => c.CourseType,
							c => c.CourseCredit,
							c => c.CourseDescription,
							c => c.CourseSchedule.ClassTime1,
							c => c.CourseSchedule.ClassPlace2,
							c => c.CourseSchedule.ClassTime2,
							c => c.CourseSchedule.ClassPlace2
						))
						{
							try
							{
								await _db.SaveChangesAsync();
							}
							catch (DbUpdateException)
							{
								ModelState.AddModelError("", "Unable to save changes. " +
								"Try again, and if the problem persists, " +
								"see your system administrator.");
							}
						}
					}

						return RedirectToAction(nameof(Index));
				}

				return View(viewModel.Course);
			}*/

		private void PopulateCourseTypeList()
		{
			List<SelectListItem> courseTypeList = new List<SelectListItem>();
			foreach (var courseType in StaticDetails.CourseTypes)
			{
				courseTypeList.Add(new SelectListItem
				{
					Text = courseType,
					Value = StaticDetails.CourseTypes.IndexOf(courseType).ToString()
				});
			}

			ViewBag.CourseTypeDropdownList = courseTypeList;
		}


		private void GetCourseAssignmentDropdownList(int? courseID)
		{
			var courseAssigments = _db.CourseAssignments.Where(c => c.CourseID == courseID)
									.AsNoTracking()
									.Include(l => l.Lecturer).ToList();
			ViewBag.CourseID = new SelectList(courseAssigments, "CourseID", "CourseName", courseID);
		}


		private void GetCourseAssignments(int courseId)
		{
			var getCoursesByLecturerId = _db.CourseAssignments
						.Include(l => l.Lecturer)
						.FirstOrDefault(c => c.CourseID == courseId);

		}

		private IList<SelectListItem> GetCourseTypeDropdownList()
		{

			List<SelectListItem> courseTypeListItem = new List<SelectListItem>();
			foreach (var courseType in StaticDetails.CourseTypes)
			{
				courseTypeListItem.Add(new SelectListItem { Text = courseType, Value = StaticDetails.CourseTypes.IndexOf(courseType).ToString() });
			}

			return courseTypeListItem;
		}


		#region APIs CALL
		[HttpGet]
		public IActionResult GetAll()
		{
			var objDetails = _db.Course.ToList();
			return Json(new { data = objDetails });
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var objToDelete = _db.Course.Find(id);
			if (objToDelete == null)
				return Json(new { success = false, messge = "Error while deleting." });

			_db.Course.Remove(objToDelete);
			_db.SaveChanges();
			return Json(new { success = true, mesage = "Deleted successfully." });
		}

		#endregion 


	}
}