using Microsoft.AspNetCore.Mvc;
using Moq;
using SechedulingMVCAppReamer.Controllers;
using SechedulingMVCAppReamer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SchedulingTests
{
    public class InstructorsControllerShould
    {
        [Fact]
        public async Task AddNewInstructor()
        {
            Mock<IInstructorRepository>
                mockInstructorRepository =
                new Mock<IInstructorRepository>();

            Instructor addedInstructor = null;

            mockInstructorRepository.Setup(m => m.AddInstructor(It.IsAny<Instructor>()))
                .Returns(Task.CompletedTask)
                .Callback<Instructor>(m => addedInstructor = m);

            InstructorsController instructorsController
                = new InstructorsController
                (mockInstructorRepository.Object);

            Instructor instructor = new Instructor("Grahm", "Peace", "Grahm.Peace@mail.wvu.edu", 1);
            instructor.InstructorID = 1;
            //act

           var result = await instructorsController.AddInstructor(instructor);
            
            Assert.Equal(instructor.InstructorLastName, addedInstructor.InstructorLastName);
            Assert.Equal(instructor, addedInstructor);
        }
        [Fact]
        public void ReturnViewForListAllInstructors()

        {
            Mock<IInstructorRepository>
                mockInstructorRepository =
                new Mock<IInstructorRepository>();

            List<Instructor> mockInstructorList =
                PopulateInstructors();

            mockInstructorRepository
                .Setup(m => m.ListAllInstructors())
                .Returns(mockInstructorList);
                

            InstructorsController instructorsController 
                = new InstructorsController
                (mockInstructorRepository.Object);

            var result = 
                instructorsController.ListAllInstructors();


            ViewResult viewResult = Assert.IsType<ViewResult>(result);

           List<Instructor> viewResultModel = (List<Instructor>) viewResult.Model;

            int expectedNumberOfInstructors = 5;

            Assert.Equal(expectedNumberOfInstructors,
                viewResultModel.Count);

            string expectedEmail = "Grahm.Peace@mail.wvu.edu";
            string actualEmail = 
                viewResultModel
                .Find(i => i.InstructorID == 1)
                .InstructorEmail;

            Assert.Equal(expectedEmail, actualEmail);

            Assert.Equal(mockInstructorList,
                viewResultModel);

        }
        private List<Instructor> PopulateInstructors()
        {
            List<Instructor> instructorList = new List<Instructor>();

            Instructor instructor = new Instructor("Grahm", "Peace", "Grahm.Peace@mail.wvu.edu", 1);
            instructor.InstructorID = 1;
            instructorList.Add(instructor);

            instructor = new Instructor("Kliest", "Virginia", "Kliest.Virginia@mail.wvu.edu", 1);
            instructor.InstructorID = 2;

            instructorList.Add(instructor);

            instructor = new Instructor("Surrendra", "Nanda", "Surrendra.Nanda@mail.wvu.edu", 1);
            instructor.InstructorID = 3;
            instructorList.Add(instructor);


            instructor = new Instructor("Dalton", "Cindy", "Dalton.Cindy@mail.wvu.edu", 2);
            instructor.InstructorID = 4;
            instructorList.Add(instructor);

            instructor = new Instructor("Ball", "Suzanne", "Ball.Suzanne@mail.wvu.edu", 3);
            instructor.InstructorID = 5;
            instructorList.Add(instructor);

            return instructorList;
        }
    }
}
