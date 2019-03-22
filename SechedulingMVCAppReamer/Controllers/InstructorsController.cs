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
    public class InstructorsController : Controller

    {
        private IInstructorRepository instructorRepositoryInterface;

        //Dependency Inversion
        public InstructorsController(IInstructorRepository repository)
        {
            this.instructorRepositoryInterface = repository;

        }



        public IActionResult ListAllInstructors()
        {
            //List<Instructor> instructors = database.Instructors.Include(I => I.Department).ToList<Instructor>();
            List<Instructor> instructors = instructorRepositoryInterface.ListAllInstructors();


            return View(instructors);
        }

        //add and edit: two methods for each, (one get, and one post)
        [HttpGet]
        public IActionResult AddInstructor()
        {
            ViewData["Departments"] = new SelectList(instructorRepositoryInterface.ListAllDepartments(), "DepartmentID", "DepartmentName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInstructor
            (
            [Bind
            ("InstructorID, InstructorFirstName, InstructorLastName, InstructorEmail, DepartmentID")] Instructor instructor
            )

        {
            /*
            database.Instructors.AddAsync(instructor);
            database.SaveChangesAsync();
            
            */
            await instructorRepositoryInterface.AddInstructor(instructor);
            return RedirectToAction("ListAllInstructors");
        }
        public async Task<IActionResult> DeleteInstructor(int? id)
        {
            await instructorRepositoryInterface.DeleteInstructor(id);
            return RedirectToAction("ListAllInstructors");

        }
    }
}