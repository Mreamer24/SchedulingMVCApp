using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SechedulingMVCAppReamer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SechedulingMVCAppReamer.Data
{
    public class DbInitializer
    {
        public async static Task  Initialize(IServiceProvider services)
        {
            //change from accessing just the database service, add user and role services

            var database = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            
            
             if (!database.Departments.Any())
             {
               List<Department> departmentList = Department.PopulateDepartments();

                database.Departments.AddRange(departmentList);
                database.SaveChanges(); 
             }
           
             

             if (!database.Courses.Any())
             {
                  List<Course> courseList = Course.PopulateCourses();

                database.Courses.AddRange(courseList);
                database.SaveChanges();  
             }

                

            string roleDepartmentChair = "DepartmentChair";
            string roleCoordinator = "Coordinator";

            if (!database.Roles.Any())
            {
                IdentityRole role = new IdentityRole(roleCoordinator);
                await roleManager.CreateAsync(role);

                role = new IdentityRole(roleDepartmentChair);
                await roleManager.CreateAsync(role);
            }
           

            List<ApplicationUser> appUserList =
                ApplicationUser.PopulateUsers();


            if (!database.Users.Any())
            {


                foreach (ApplicationUser eachCoordinator in appUserList)
                {

                    await userManager.CreateAsync(eachCoordinator);
                    await userManager.AddToRoleAsync(eachCoordinator, roleCoordinator);
                }
            }

            List<DepartmentChair> chairList =
                DepartmentChair.PopulateDapartmentChair();


            if (!database.DepartmentChairs.Any())
            {
                
                foreach (ApplicationUser eachDepartmentChair in chairList)
                {
                    await userManager.CreateAsync(eachDepartmentChair);
                    await userManager.AddToRoleAsync(eachDepartmentChair, roleDepartmentChair);
                }
            }

            if (!database.ConflictCourses.Any())
            {
                List<ConflictCourse> conflictCourseList =
                    ConflictCourse.PopulateConflictCourses();
                database.ConflictCourses.AddRange(conflictCourseList);
                database.SaveChanges();
            }

            if (!database.Instructors.Any())
            {
                List<Instructor> instructorList =
                    Instructor.PopulateInstructors();
                database.Instructors.AddRange(instructorList);
                database.SaveChanges();
            }
            if (!database.CourseOfferings.Any())
            {
                List<CourseOffering> courseOfferingsList =
                    CourseOffering.PopulateCourseOfferings();
                database.CourseOfferings.AddRange(courseOfferingsList);
                database.SaveChanges();
            }
            //if (!database.Departments.Any())
            //{
                List<Department> departments =
                    database.Departments.ToList<Department>();

                List<DepartmentChair> departmentChairs =
                   database.DepartmentChairs.ToList <DepartmentChair>();

               departments[0].DepartmentChairID = departmentChairs[0].DepartmentChairID;
                database.Departments.Update(departments[0]);

               departments[1].DepartmentChairID = departmentChairs[1].DepartmentChairID;
                database.Departments.Update(departments[1]);

                departments[2].DepartmentChairID = departmentChairs[2].DepartmentChairID;
                database.Departments.Update(departments[2]);

                database.SaveChanges();


           // }
            if (!database.TeachingQualifications.Any())
            {
              
            List<TeachingQualification> teachingQualificationsList 
                    = TeachingQualification.PopulateTeachingQualifications();

            database.TeachingQualifications.AddRange(teachingQualificationsList);
            database.SaveChanges();
            }
            
            if (!database.CourseOfferingChanges.Any())
            {
                List<CourseOfferingChanges> courseOfferingChangesList =
                    CourseOfferingChanges.PopulateCourseOfferingChanges();
                database.CourseOfferingChanges.AddRange(courseOfferingChangesList);
                database.SaveChanges();
                
            }
        }
    }
}


    

