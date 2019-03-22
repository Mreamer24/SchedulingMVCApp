using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SechedulingMVCAppReamer.Data;
using SechedulingMVCAppReamer.Models;

namespace SechedulingMVCAppReamer.Controllers
{
    public class CourseOfferingChangesController : Controller
    {
        private ApplicationDbContext database;

        //constructor

        public CourseOfferingChangesController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }

        public IActionResult GetAllCourseOfferingChanges()
        {
            List<CourseOfferingChanges> courseOfferingChangesList =
                database.CourseOfferingChanges.Include(cc => cc.Course).Include(cc => cc.Course.Department).Include(cc => cc.Instructor).ToList<CourseOfferingChanges>();

            // List<Department> departmentList =
            //  database.Departments.ToList<Department>();

            return View(courseOfferingChangesList);
        }
    }
}