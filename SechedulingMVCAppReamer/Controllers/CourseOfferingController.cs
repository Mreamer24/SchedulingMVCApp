using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SechedulingMVCAppReamer.Data;
using SechedulingMVCAppReamer.Models;
using SechedulingMVCAppReamer.Models.ViewModels;

namespace SechedulingMVCAppReamer.Controllers
{
    public class CourseOfferingsController : Controller
    {
        //attribute
        private ApplicationDbContext database;

        //constructor

        public CourseOfferingsController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public IActionResult SearchCourseOfferings()
        {
            //1. By Department (Name, ID)

            ViewData["Departments"] = new SelectList(database.Departments, "DepartmentID", "DepartmentName");

            //2. By Instructor (LastName, ID)
            ViewData["Instructors"] = new SelectList(database.Instructors, "InstructorID", "InstructorLastName");


            return View();
        }
        [HttpPost]
        public IActionResult SearchResult(int? DepartmentID, int? InstructorID, DateTime? StartTime, DateTime? EndTime)
        {

            List<CourseOffering> courseOfferingsList = database.CourseOfferings.Include(co => co.Course).Include(co => co.Course.Department).Include(co => co.Instructor).ToList<CourseOffering>();

            if (DepartmentID != null)
            { courseOfferingsList = courseOfferingsList.Where(co => co.Course.DepartmentID == DepartmentID).ToList<CourseOffering>(); }

            if (InstructorID != null)
            { courseOfferingsList = courseOfferingsList.Where(co => co.InstructorID == InstructorID).ToList<CourseOffering>(); }

            if (StartTime != null)
            { courseOfferingsList = courseOfferingsList.Where(co => co.StartTime.TimeOfDay >= StartTime.Value.TimeOfDay).ToList<CourseOffering>(); }

            if (EndTime != null)
            { courseOfferingsList = courseOfferingsList.Where(co => co.EndTime.TimeOfDay <= EndTime.Value.TimeOfDay).ToList<CourseOffering>(); }


            return View(courseOfferingsList);
        }
        //LINQ
        //Lambda Expression
        public IActionResult SearchNoInstructors()

        {
            string departmentChairID = null;
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("DepartmentChair"))
                {
                     departmentChairID = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
            }
                
                
            List<CourseOffering> courseOfferingsListed = database.CourseOfferings.Include(co => co.Course).Include(co => co.Course.Department).Include(co => co.Instructor).Where(
                co => co.InstructorID == null
                ).ToList<CourseOffering>();

           // courseOfferingsListed = courseOfferingsListed.Where(
             //   co => co.InstructorID == null 
             //   ).ToList<CourseOffering>();

            if(departmentChairID != null)
            {
                courseOfferingsListed
                = courseOfferingsListed.Where(
                    co => co.Course.Department.DepartmentChairID == departmentChairID 
                    ).ToList<CourseOffering>();
            }

            return View(courseOfferingsListed);
        }

        public IActionResult FindQualifiedInstructors(int? id)
        {
            int courseOfferingID = Convert.ToInt32(id);
            HttpContext.Session.SetInt32("CourseOfferingID", courseOfferingID);


           CourseOffering courseOffering = 
                database.CourseOfferings.Find(id);
            int courseID = courseOffering.CourseID;

            List<Instructor> instructorList =
                database.Instructors
                .Include(i => i.Department)
                .Where
                (
                     i => i.QualifiedCourses.Any(qc => qc.CourseID == courseID)
                ).ToList<Instructor>();

            return View(instructorList);
        }
        [Authorize(Roles = "DepartmentChair" + "Coordinator")]
        //create assigninstructor
        public IActionResult AssignInstructorToCourseOffering(int? id)
        {
            int? instructorID = id;
            int courseOfferingID = HttpContext.Session.GetInt32("CourseOfferingID").Value;

           CourseOffering courseOffering
                = database.CourseOfferings.Find(courseOfferingID);
            courseOffering.InstructorID = instructorID;
            database.CourseOfferings.Update(courseOffering);
            database.SaveChanges();
            return RedirectToAction("SearchNoInstructors");
            

        }

        [HttpGet]
        public IActionResult AddCourseOffering()
        {
            PopulateDropDownLists();
            return View();
        }

      private void PopulateDropDownLists()
        {
            List<DaysOfWeekViewModel> daysOfWeekViewModelList
    = new List<DaysOfWeekViewModel>();

            DaysOfWeekViewModel daysOfWeekViewModel
                = new DaysOfWeekViewModel
                {
                    DaysOfWeek = "M, W, F"
                };

            daysOfWeekViewModelList.Add(daysOfWeekViewModel);

            daysOfWeekViewModel
                = new DaysOfWeekViewModel
                {
                    DaysOfWeek = "T, H"
                };

            daysOfWeekViewModelList.Add(daysOfWeekViewModel);

            daysOfWeekViewModel
                = new DaysOfWeekViewModel
                {
                    DaysOfWeek = "M, T, W, H, F"
                };

            daysOfWeekViewModelList.Add(daysOfWeekViewModel);

            ViewData["DaysOfWeekValues"] =
                new SelectList(daysOfWeekViewModelList,
                "DaysOfWeek", "DaysOfWeek");

            ViewData["Instructors"] =
                new SelectList(database.Instructors, "InstructorID", "InstructorFullName");

            ViewData["Courses"] =
            new SelectList(database.Courses, "CourseID", "CourseName");

        }

        [HttpPost]
        public IActionResult AddCourseOffering(
            [Bind("CourseOfferingID, CRN, Days, StartTime, EndTime, " +
            "StartDate, EndDate, CourseID, InstructorID")]
            CourseOffering courseOffering)
        {
            database.CourseOfferings.Add(courseOffering);
            database.SaveChanges();

            AddCourseOfferingChangesChanges(courseOffering, "Add");

            return RedirectToAction("SearchCourseOfferings");
        }
        public IActionResult DeleteCourseOffering(int? id)
        {
            CourseOffering courseOffering = database.CourseOfferings.Find(id);
            database.CourseOfferings.Remove(courseOffering);
            database.SaveChanges();

            AddCourseOfferingChangesChanges(courseOffering, "Delete");
            return RedirectToAction("SearchCourseOfferings");
        }
        [HttpGet]
        public IActionResult EditCourseOffering(int? id)
        {
            CourseOffering courseOffering =
                database.CourseOfferings.Find(id);

            PopulateDropDownLists();
            return View(courseOffering);
        }

        [HttpPost]
        public IActionResult EditCourseOffering(
            [Bind("CourseOfferingID, CRN, Days, StartTime, EndTime, " +
            "StartDate, EndDate, CourseID, InstructorID")]
            CourseOffering courseOffering)
        {
            database.CourseOfferings.Update(courseOffering);
            database.SaveChanges();

            AddCourseOfferingChangesChanges(courseOffering, "Edit");

            return RedirectToAction("SearchCourseOfferings");
        }

        private void AddCourseOfferingChangesChanges
            (CourseOffering courseOffering, string changeType)
        {

            
            string crn = courseOffering.CRN;
            string days = courseOffering.Days;
            DateTime startTime = courseOffering.StartTime;
            DateTime endTime = courseOffering.EndTime;
            DateTime startDate = courseOffering.StartDate;
            DateTime endDate = courseOffering.EndDate;
            int? instructorID = courseOffering.InstructorID;
            int courseID = courseOffering.CourseID;



            string userID
                = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ApplicationUser applicationUser =
                database.Users.Find(userID);
            string changerName = applicationUser.Lastname;
            string changersRole = null;
            if (User.IsInRole("DepartmentChair"))
            {
                changersRole = "DepartmentChair";
            }
            if (User.IsInRole("Coordinator"))
            {
                changersRole = "Coordinator";
            }



            CourseOfferingChanges courseOfferingChanges = new CourseOfferingChanges(changerName, changersRole, changeType, crn, days,
            startTime, endTime, startDate, endDate,
            instructorID, courseID);

            database.CourseOfferingChanges.Add(courseOfferingChanges);
            database.SaveChanges();

        }
    }   
}