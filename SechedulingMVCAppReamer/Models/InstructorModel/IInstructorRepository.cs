using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public interface IInstructorRepository
    {
        //list of actions (methods)
       List<Instructor> ListAllInstructors();

        Task AddInstructor(Instructor instructor);

        Task DeleteInstructor(int? id);

       List<Department> ListAllDepartments();
    }
}
