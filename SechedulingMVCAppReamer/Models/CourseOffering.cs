using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public class CourseOffering
    {
        [Key]
        public int CourseOfferingID { get; set; }

        public string CRN { get; set; }

        public string Days { get; set; }

        [DataType(DataType.Time)]

        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]

        public DateTime EndTime { get; set; }

        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]

        public DateTime EndDate { get; set; }

        public int? InstructorID { get; set; }
        
        public int CourseID { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Instructor { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        List<CourseOffering> CourseOfferings { get; set; }

        public CourseOffering() { }

        public CourseOffering(string crn, string days,
            DateTime startTime, DateTime endTime, DateTime startDate, DateTime endDate,
            int? instructorID, int courseID)
        {
            this.CRN = crn;
            this.Days = days;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.InstructorID = instructorID;
            this.CourseID = courseID;
        }

        public static List<CourseOffering> PopulateCourseOfferings()
        {
            List<CourseOffering> courseOfferingsList = new List<CourseOffering>();
            string days = "M, W, F";
            DateTime startTime = DateTime.Parse("8:30 AM");
            DateTime endTime = DateTime.Parse("9:20 AM");

            DateTime startDate = new DateTime(2018, 8, 15);
            DateTime endDate = new DateTime(2018, 12, 15);

            days = "T, H";
            startTime = DateTime.Parse("9:30 AM");
            endTime = DateTime.Parse("10:45 AM");

            CourseOffering courseOffering = new CourseOffering("12345", days,
                startTime, endTime, startDate, endDate, 1, 1);
            courseOfferingsList.Add(courseOffering);

            days = "T,H";
            startTime = DateTime.Parse("8:30 AM");
            endTime = DateTime.Parse("9:45 AM");

            days = "T,H";
            startTime = DateTime.Parse("10:00 AM");
            endTime = DateTime.Parse("11:15 AM");

            courseOffering = new CourseOffering("32345", days,
                startTime, endTime, startDate, endDate, 3, 3);
            courseOfferingsList.Add(courseOffering);

            startDate = new DateTime(2018, 10, 1);

            days = "M, W, F";
            startTime = DateTime.Parse("9:30 AM");
            endTime = DateTime.Parse("10:20 AM");

            courseOffering = new CourseOffering("42345", days,
               startTime, endTime, startDate, endDate, 3, 3);
            courseOfferingsList.Add(courseOffering);

            courseOffering = new CourseOffering("102233", days, startTime, endTime, startDate, endDate, null, 3);
            courseOfferingsList.Add(courseOffering);

            courseOffering = new CourseOffering("11223", days,
    startTime, endTime, startDate, endDate, 1, 4);
            courseOfferingsList.Add(courseOffering);

            days = "M, W, F";
            startTime = DateTime.Parse("11:30 AM");
            endTime = DateTime.Parse("12:20 PM");

            //Create another course offering object
            courseOffering = new CourseOffering("11224", days,
                startTime, endTime, startDate, endDate, null, 5);
            courseOfferingsList.Add(courseOffering);

            days = "T, H";
            startTime = DateTime.Parse("10:30 AM");
            endTime = DateTime.Parse("11:45 PM");

            //Create another course offering object
            courseOffering = new CourseOffering("11225", days,
                startTime, endTime, startDate, endDate, null, 6);
            courseOfferingsList.Add(courseOffering);

            return courseOfferingsList;
        }

    }
}
