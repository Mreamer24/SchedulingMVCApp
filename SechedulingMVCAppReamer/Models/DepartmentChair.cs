using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Models
{
    public class DepartmentChair : ApplicationUser
    {
        //Only case where ID is a string
        public string DepartmentChairID { get; set; }

        //Link to Department

        public int DepartmentID { get; set; }

        //Object oriented connection to User.
        //Relational connection (FK)
        [ForeignKey("DepartmentChairID")]
        ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }


        public DepartmentChair() { }

        public DepartmentChair
            (string firstname, string lastname, string email,
            string phone, string password, int departmentID) :

            base(firstname, lastname, email, phone, password)

        {
            this.DepartmentID = departmentID;
            this.DepartmentChairID = this.Id;
        }//end of constructor

        public static List<DepartmentChair> PopulateDapartmentChair()
        {
            List<DepartmentChair> listOfChairs = new List<DepartmentChair>();
            DepartmentChair chair = new DepartmentChair("Test", "MISChair1", "TestMISChair1@wvu.edu", "304-111-1111", "TestMISChair1", 1);
            listOfChairs.Add(chair);
            chair = new DepartmentChair("Test2", "ACTChair2", "TestACTChair2@wvu.edu", "304-111-1112", "TestACTChair2", 2);
            listOfChairs.Add(chair);
            chair = new DepartmentChair("Test3", "MKTChair3", "TestMKTChair3@wvu.edu", "304-111-1113", "TestMKTChair3", 3);
            listOfChairs.Add(chair);
            return listOfChairs;
        }


    }//end class

}//end namespace
