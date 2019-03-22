using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public class Instructor : IComparable<Instructor>
    {
        [Key]
        public int InstructorID { get; set; }
        [Required]
        public string InstructorFirstName { get; set; }
        [Required]
        public string InstructorLastName { get; set; }
        public string InstructorFullName
        {
            get { return InstructorFirstName
                    + " " + InstructorLastName; }
        }
        [Required]
        public string InstructorEmail { get; set; }

        public int DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        public List<TeachingQualification> QualifiedCourses { get; set; }

        public Instructor()
        { }

        public Instructor(string firstname, string lastname, string email, int departmentID)
        {
            this.InstructorFirstName = firstname;
            this.InstructorLastName = lastname;
            this.InstructorEmail = email;
            this.DepartmentID = departmentID;
        }

        public static List<Instructor> PopulateInstructors()
        {
            List<Instructor> instructorList = new List<Instructor>();

            Instructor instructor = new Instructor("Grahm", "Peace", "Grahm.Peace@mail.wvu.edu", 1);
            instructorList.Add(instructor);

            instructor = new Instructor("Kliest", "Virginia", "Kliest.Virginia@mail.wvu.edu", 1);
            instructorList.Add(instructor);

            instructor = new Instructor("Surrendra", "Nanda", "Surrendra.Nanda@mail.wvu.edu", 1);
            instructorList.Add(instructor);

            instructor = new Instructor("Dalton", "Cindy", "Dalton.Cindy@mail.wvu.edu", 2);
            instructorList.Add(instructor);

            instructor = new Instructor("Ball", "Suzanne", "Ball.Suzanne@mail.wvu.edu", 3);
            instructorList.Add(instructor);

            return instructorList;

        }

        public int CompareTo(Instructor other)
        {
            if(this.InstructorID == other.InstructorID)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
