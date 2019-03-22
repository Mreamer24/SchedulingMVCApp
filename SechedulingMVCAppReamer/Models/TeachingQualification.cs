using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
   
        public class TeachingQualification
        {
            [Key]
            public int TeachingQualificationID { get; set; }

            public int InstructorID { get; set; }

            public int CourseID { get; set; }

            [ForeignKey("InstructorID")]

            public Instructor Instructor { get; set; }

            [ForeignKey("CourseID")]

            public Course Course { get; set; }


            public TeachingQualification()
            { }

            public TeachingQualification(int instructorID, int courseID)
            {
                this.InstructorID = instructorID;
                this.CourseID = courseID;

            }

            public static List<TeachingQualification> PopulateTeachingQualifications()
            {
                List<TeachingQualification> teachingQualificationList = new List<TeachingQualification>();

                TeachingQualification teachingQualification = new TeachingQualification(1, 1);
                teachingQualificationList.Add(teachingQualification);

                teachingQualification = new TeachingQualification(1, 2);
                teachingQualificationList.Add(teachingQualification);

                teachingQualification = new TeachingQualification(2, 1);
                teachingQualificationList.Add(teachingQualification);

                teachingQualification = new TeachingQualification(2, 2);
                teachingQualificationList.Add(teachingQualification);

                teachingQualification = new TeachingQualification(3, 1);
                teachingQualificationList.Add(teachingQualification);

                teachingQualification = new TeachingQualification(3, 2);
                teachingQualificationList.Add(teachingQualification);

                teachingQualification = new TeachingQualification(4, 3);
                teachingQualificationList.Add(teachingQualification);

                teachingQualification = new TeachingQualification(4, 4);
                teachingQualificationList.Add(teachingQualification);

                return teachingQualificationList;
            }



        }


    }