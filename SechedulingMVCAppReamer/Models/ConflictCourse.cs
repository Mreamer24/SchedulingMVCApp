using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public class ConflictCourse
    {
        [Key]
        public int ConflictCourseID { get; set; }

        //connect for relational
        public int CourseID { get; set; }
        public int ConflictedCourseID { get; set; }

        //connect of object-orientation
        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        [ForeignKey("ConflictedCourseID")]
        public ConflictCourse conflictedCourse { get; set; }

        public ConflictCourse() { }

        public ConflictCourse(int courseID,
            int conflictingCourseID)
        {
            this.CourseID = courseID;
            this.ConflictedCourseID = conflictingCourseID;
        }

        public static List<ConflictCourse>
            PopulateConflictCourses()
        {
            List<ConflictCourse> conflictCourselist
                = new List<ConflictCourse>();

            ConflictCourse conflictCourse
                = new ConflictCourse(1, 2);
            conflictCourselist.Add(conflictCourse);

            conflictCourse = new ConflictCourse(2, 1);
            conflictCourselist.Add(conflictCourse);

            conflictCourse = new ConflictCourse(3, 4);
            conflictCourselist.Add(conflictCourse);

            conflictCourse = new ConflictCourse(4, 3);
            conflictCourselist.Add(conflictCourse);

            return conflictCourselist;
        }
    }
}
