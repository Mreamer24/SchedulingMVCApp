using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SechedulingMVCAppReamer.Data;
using SechedulingMVCAppReamer.Models;


namespace SechedulingMVCAppReamer.Controllers
{ 
  public class DepartmentChairsController : Controller
{
    // Department Chair Full Name, Department Name
    //Index
    //Need to access the Database object
    //Concept: Dependency Inversion (DI)

    //attribute (Not property)
    private ApplicationDbContext database;

    //Constructor for the controller, has same name as the class & no return type & 
    public DepartmentChairsController(ApplicationDbContext dbContext)
    {

        this.database = dbContext;

    }

    public IActionResult GetAllDepartmentChairs()
    {

        List<DepartmentChair> departmentChairsList = database.DepartmentChairs.Include(dc => dc.Department).ToList<DepartmentChair>();
        //ViewData and ViewBag
        //DropDownList and Single variable data

        return View(departmentChairsList);
    }
}
}