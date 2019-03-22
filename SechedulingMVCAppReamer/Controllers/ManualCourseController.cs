using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SechedulingMVCAppReamer.Data;
using SechedulingMVCAppReamer.Models;

namespace SechedulingMVCAppReamer.Controllers
{
    public class ManualCourseController : Controller
    {

        private ApplicationDbContext database;

        //constructor
        public ManualCourseController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public IActionResult GetAllCourses()
        {
            List<Course> courseList =
                database.Courses.Include(c => c.Department).ToList<Course>();

            // List<Department> departmentList =
            //  database.Departments.ToList<Department>();

            return View(courseList);


        }//end of method, getallcourses

        [Authorize(Roles = "Department Chair")]
        public IActionResult SearchForCoursesByDepartment()
        {
            //Design choice to hard code small list of items and not pull from database.
            //List<String> semesterList = new List<String>();
            //semesterList.Add("Fall");


            ViewData["Departments"] = new SelectList(database.Departments, "DepartmentID", "DepartmentName");
            return View("SearchForCourses");

        }

        public IActionResult FindCoursesByDepartment(int? departmentID)

        {


            List<Course> courseList =
            database.Courses.Include(c => c.Department).ToList<Course>();


            if (departmentID != null)
            {
                courseList = courseList.Where(c => c.DepartmentID == departmentID).ToList<Course>();
            }




            return View("SearchResult", courseList);


        }

    }//end class
}//end namespace