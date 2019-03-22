using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SechedulingMVCAppReamer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }

        public string Lastname { get; set;  }

        public ApplicationUser() { }

        public ApplicationUser(string firstname, string lastname, 
            string email, string phone, string password)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Email = email;
            this.PhoneNumber = phone;
        
            PasswordHasher<ApplicationUser> passwordHasher
                = new PasswordHasher<ApplicationUser>();

            this.PasswordHash = passwordHasher.HashPassword(this,password);
            this.SecurityStamp = Guid.NewGuid().ToString();
            this.UserName = email;

        }

        public static List<ApplicationUser> PopulateUsers()
        {
            List<ApplicationUser> listUsers = new List<ApplicationUser>();
            ApplicationUser applicationUser = new ApplicationUser("Test", "Coordinator1", "TestCoordinator1@wvu.edu", "304-000-0001", "TestCoordinator1");
            listUsers.Add(applicationUser);
              
           
            applicationUser = new ApplicationUser("Test2", "Coordinator2", "TestCoordinator2@wvu.edu", "304-000-0002", "TestCoordinator2");
            listUsers.Add(applicationUser);
            return listUsers;
        }

    }
}
