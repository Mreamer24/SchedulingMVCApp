using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public class CourseOfferingChanges
    {
        [Key]
        public int CourseOfferingChangesID { get; set; }

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
        
        public string ChangeType { get; set; }
        public string ChangersName { get; set; }
        public string ChangersRole { get; set; }
        public DateTime DateChanged { get; set; }

        [ForeignKey("InstructorID")]
        public Instructor Instructor { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public CourseOfferingChanges() { }

        public CourseOfferingChanges(string crn, string changersName, string changersRole, string changeType, string days,
            DateTime startTime, DateTime endTime, DateTime startDate, DateTime endDate,
            int? instructorID, int CourseID)
        {
            this.ChangeType = changeType;
            this.ChangersName = changersName;
            this.ChangersRole = changersRole;
            this.DateChanged = DateTime.Now;
            this.CRN = crn;
            this.Days = days;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.InstructorID = instructorID;
            this.CourseID = CourseID;

        }
        public static List<CourseOfferingChanges> PopulateCourseOfferingChanges()
        {
            List<CourseOfferingChanges> courseOfferingChangesList = new List<CourseOfferingChanges>();
            string days = "M, W, F";
            DateTime startTime = DateTime.Parse("8:30 AM");
            DateTime endTime = DateTime.Parse("9:20 AM");

            DateTime startDate = new DateTime(2018, 8, 15);
            DateTime endDate = new DateTime(2018, 12, 15);

           
            

            string changersName = "Coordinator1";
            string changersRole = "Coordinator";
            string changeType = "Add";

            
            CourseOfferingChanges courseOfferingChanges = new CourseOfferingChanges(changersName, changersRole, changeType,"12345", days,
                startTime, endTime, startDate, endDate, null, 1);
            courseOfferingChangesList.Add(courseOfferingChanges);
            
            return courseOfferingChangesList;

     }
    }
}
