using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    /* 
                 * Migrations from C# Classes to the Database Tables 
        1. Add-Migration  Initial 
        2. Update-Database 

        -- Revert back to the original (step 0 - before migration) 
        3. "Update-Database -Migration 0"
        4. Add-Migration AddedDepartment
        5. Update-Database

        --
        6. Update-Database -Migration 0
        7. Add-Migration AddedDepartment 
        8. Update-Database

 * 
 */
    public class Course
    {
        [Key]
        [Required]
        public int CourseID { get; set; }
        [Required]

        public string CourseNumber { get; set;  }
        [Required]
        public string CourseName { get; set; }
        [Required]

        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public List<TeachingQualification> QualifiedInstructors { get; set; }

        public List<CourseOffering> CourseOfferings { get; set; }

        public Department Department { get; set; }

        public Course()
        {

        }
        public Course(string courseNumber,
            string courseName, int departmentID)
        {
            this.CourseNumber = courseNumber;
            this.CourseName = courseName;
            this.DepartmentID = departmentID;

        }
        public static List<Course> PopulateCourses()
        {
            List<Course> courseList =
                new List<Course>();

            Course course =
                new Course("MIST 450", "Systems Analysis", 1);
            courseList.Add(course);

            course =
                new Course("MIST 353", "Advance IT Analysis", 1);
                courseList.Add(course);

            course =
                new Course("ACCT 101", "Intro to Accounting", 2);
            courseList.Add(course);

            course =
                new Course("ACCT 202", "Intermediate Accounting", 2);
            courseList.Add(course);

            return courseList;
        }
    }
}
