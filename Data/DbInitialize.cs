using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using identity_2auth_mvc.Data;
using identity_2auth_mvc.Models.Klas;
using identity_2auth_mvc.Utilities;

namespace identity_2auth_mvc.Data
{
	public class DbInitialize
	{
		public static void InitializeDb(ApplicationDbContext context)
		{

			throw new NotImplementedException();
			context.Database.EnsureCreated();
			if (context.Course.Any())
				return;

		/*	var courses = new Course[]
			{
				new Course{ CourseID=1101, CourseName="Data Structure", CourseCredit = StaticDetails.CourseCredit3, CourseType = StaticDetails.CourseTypeRequried},
				new Course{ CourseID=1102, CourseName="Algorithm", CourseCredit = StaticDetails.CourseCredit3, CourseType = StaticDetails.CourseTypeRequried},
				new Course{ CourseID=1103, CourseName="Discrete Math", CourseCredit = StaticDetails.CourseCredit3, CourseType = StaticDetails.CourseTypeRequried},
				new Course{ CourseID=1104, CourseName="Datdabase", CourseCredit = StaticDetails.CourseCredit3, CourseType = StaticDetails.CourseTypeRequried},
				new Course{ CourseID=1105, CourseName="English Conversation", CourseCredit = StaticDetails.CourseCredit2, CourseType = StaticDetails.CourseTypeElective},
			};

			foreach (Course course in courses)
				context.Course.Add(course);
			context.SaveChanges();*/

			/*	var courseLecturers = new CourseAssignment[]
				{
					new CourseAssignment
					{
						CourseID = courses.Single(c => c.CourseName == "Data Structure").CourseID,
						LecturerID =
					}
				};
	*/

		/*	var courseSchedules = new CourseSchedule[]
			{
				new CourseSchedule
				{
					ClassPlace1 = "새빛관", ClassTime1 = "월요일 3교시",
					ClassPlace2 = "새빛관", ClassTime2 = "화요일 4교시",
					CourseID = courses.Single(c => c.CourseName == "Data Structure").CourseID
				},

				new CourseSchedule
				{
					ClassPlace1 = "참빗관", ClassTime1 = "월요일 2교시",
					ClassPlace2 = "새빗관", ClassTime2 = "목요일 2교시",
					CourseID = courses.Single(c => c.CourseName == "Algorithm").CourseID
				},

				new CourseSchedule
				{
					ClassPlace1 = "화도관", ClassTime1 = "수요일 2교시",
					ClassPlace2 = "화도관", ClassTime2 = "수요일 3교시",
					CourseID = courses.Single(c => c.CourseName == "Discrete Math").CourseID
				},

				new CourseSchedule
				{
					ClassPlace1 = "의옥관", ClassTime1 = "금요일 1교시",
					ClassPlace2 = "의옥관", ClassTime2 = "금요일 2교시",
					CourseID = courses.Single(c => c.CourseName == "Database").CourseID
				},
				
				new CourseSchedule
				{
					ClassPlace1 = "비마관", ClassTime1 = "수요일 4교시",
					ClassPlace2 = "비마관", ClassTime2 = "화요일 5교시",
					CourseID = courses.Single(c => c.CourseName == "English Conversation").CourseID
				}
			};

			foreach (var courseSchedule in courseSchedules)
			{
				context.CourseSchedule.Add(courseSchedule);
			}
			context.SaveChanges();
			*/
			
		}
	}
}
