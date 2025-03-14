using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLearningRoadmap.Models;
using TechLearningRoadmap.Data;
using TechLearningRoadmap.UI;

// Haya Alharbi
// 2035768
// COCS307 - Assignment 1


namespace TechLearningRoadmap.Services
{
    // manages authentication
    public class AuthService
    {
        private DataManager<UserAccount> userManager;
        private DataManager<AdminAccount> adminManager;

        public AuthService(DataManager<UserAccount> userManager, DataManager<AdminAccount> adminManager)
        {
            this.userManager = userManager;
            this.adminManager = adminManager;
        }

        public void RegisterUser()
        {
            string username = InputValidation.ValidateStringInput("Enter a username"); // ensures username is valid using the static method validate password in the input validation class
            string password = InputValidation.GetValidatedPassword(); // ensures password is valid using the static method validate password in the input validation class

            UserAccount newUser = new UserAccount(username, password); // creates a new user account object
            userManager.Insert(newUser); // adds the new user to the user manager

            Console.WriteLine("Registration successful! You can now log in.");
        }

        public Account LoginUser()
        {
            string username = InputValidation.ValidateStringInput("Enter your username"); 
            string password = InputValidation.GetHiddenPassword("Enter your password");

            UserAccount user = userManager.Search(username); // searches for the user in the user manager to verify the login credentials

            if (user != null && user.Login(username, password)) // if the user is found and the login credentials are correct
            {
                Console.WriteLine("Login successful. Back to user dashboard...");
                return user;
            }
            else // if the user is not found or the login credentials are incorrect
            {
                Console.WriteLine("Invalid credentials. Please try again.");
                return null;
            }
        }

        public Account LoginAdmin()
        {
            string username = InputValidation.ValidateStringInput("Enter admin username");
            string password = InputValidation.GetHiddenPassword("Enter admin password");

            AdminAccount admin = adminManager.Search(username); // similar to the user login, searches for the admin in the admin manager

            if (admin != null && admin.Login(username, password))
            {
                Console.WriteLine("Admin login successful. Redirecting to admin panel...");
                return admin;
            }
            else
            {
                Console.WriteLine("ّInvalid credentials. Please try again.");
                return null;
            }
        }

    }
}
