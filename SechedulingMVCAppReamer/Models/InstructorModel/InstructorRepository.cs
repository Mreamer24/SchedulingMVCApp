using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.EntityFrameworkCore;
using SechedulingMVCAppReamer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public class InstructorRepository : IInstructorRepository
    {
        private ApplicationDbContext database;

        public InstructorRepository(ApplicationDbContext dbContext)
        {
            this.database = dbContext;
        }
        public Task AddInstructor(Instructor instructor)
        {
            database.Instructors.AddAsync(instructor);
           return database.SaveChangesAsync();
        }

        public Task DeleteInstructor(int? id)
        {
            Instructor instructor = database.Instructors.Find(id);
            
                database.Instructors.Remove(instructor);
               return database.SaveChangesAsync();
        }
         
            

        

        public List<Department> ListAllDepartments()
        {
            List<Department> departments = database.Departments.ToList<Department>();

            return departments;
        }

        public List<Instructor> ListAllInstructors()
        {

          List<Instructor> instructors 
            = database.Instructors.Include(I => I.Department).ToList<Instructor>();
        
            return instructors;  
        }

        
    }
}
