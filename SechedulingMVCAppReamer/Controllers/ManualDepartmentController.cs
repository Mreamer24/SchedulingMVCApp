using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SechedulingMVCAppReamer.Data;
using SechedulingMVCAppReamer.Models;

namespace SechedulingMVCAppReamer.Controllers
{
    //Inheritance( Child : Parent ) 

    public class ManualDepartmentController : Controller
    {
        //attribute
        private ApplicationDbContext database;

        //constructor
        public ManualDepartmentController(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }


        [Authorize]
        public IActionResult GetAllDepartments()
        {
           
            List<Department> departmentList =
                database.Departments.Include(dp => dp.DepartmentChair).ToList<Department>();

            return View(departmentList);
        }
    }
}