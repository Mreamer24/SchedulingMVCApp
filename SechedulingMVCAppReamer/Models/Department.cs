using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public class Department
    {
        [Key]
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; }

        //foreign keys
        //1. Relational DB connection
        public string DepartmentChairID { get; set; }

        [ForeignKey("DepartmentChairID")]
        public DepartmentChair DepartmentChair { get; set; }


        //Construct Objects (using constructors) wont have return datatype 
        //Special methods
        //In MVC when we create own constructor, we need to add and empty constructor

        public Department(string departmentName)
        {
            this.DepartmentName = departmentName;

        }

        public Department()
        {

        }

        //accessType returnType MethodName(paramType paramName, ...)
        //static
        //Class Method (static)
        //Object / Instance Method
        public static List<Department> PopulateDepartments()
        {
            List<Department> departmentList = new List<Department>();

            Department department = new Department("Management Information Systems");
            departmentList.Add(department);

            department = new Department("Accounting");
            departmentList.Add(department);

            department = new Department("Marketing");
            departmentList.Add(department);

            return departmentList;
        }


    }//end class
}//end namespace
