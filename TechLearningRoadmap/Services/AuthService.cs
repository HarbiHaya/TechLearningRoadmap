using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using TechLearningRoadmap.Models;
using TechLearningRoadmap.Data;
using TechLearningRoadmap.UI;

namespace TechLearningRoadmap.Services
{
    /// <summary>
    /// Manages user authentication and account registration.
    /// </summary>
    public class AuthService
    {
        private DataManager<UserAccount> userManager;
        private DataManager<AdminAccount> adminManager;

        public AuthService(DataManager<UserAccount> userManager, DataManager<AdminAccount> adminManager)
        {
            this.userManager = userManager;
            this.adminManager = adminManager;
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        public void RegisterUser()
        {
            string username = InputValidation.ValidateStringInput("Enter a username");
            string password = InputValidation.ValidateStringInput("Enter a secure password (8+ characters, 1 uppercase, 1 lowercase, 1 digit, 1 special character)");

            UserAccount newUser = new UserAccount(username, password);
            userManager.Insert(newUser);
        }

        /// <summary>
        /// Handles user login and returns an account if successful.
        /// </summary>
        public Account Login()
        {
            string username = InputValidation.ValidateStringInput("Enter your username");
            string password = InputValidation.ValidateStringInput("Enter your password");

            UserAccount user = userManager.Search(username);
            AdminAccount admin = adminManager.Search(username);

            if (user != null && user.Login(username, password))
            {
                Console.WriteLine("Login successful. Redirecting to user dashboard...");
                return user;
            }
            else if (admin != null && admin.Login(username, password))
            {
                Console.WriteLine("Admin login successful. Redirecting to admin panel...");
                return admin;
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again.");
                return null;
            }
        }
    }
}

