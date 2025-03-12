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

        public void RegisterUser()
        {
            string username = InputValidation.ValidateStringInput("Enter a username");

            string password = InputValidation.GetValidatedPassword(); // Ensures password is valid

            UserAccount newUser = new UserAccount(username, password);
            userManager.Insert(newUser);

            Console.WriteLine("✅ Registration successful! You can now log in.");
        }

        public Account LoginUser()
        {
            string username = InputValidation.ValidateStringInput("Enter your username");
            string password = InputValidation.GetHiddenPassword("Enter your password");

            UserAccount user = userManager.Search(username);

            if (user != null && user.Login(username, password))
            {
                Console.WriteLine("✅ Login successful. Redirecting to user dashboard...");
                return user;
            }
            else
            {
                Console.WriteLine("❌ Invalid credentials. Please try again.");
                return null;
            }
        }

        public Account LoginAdmin()
        {
            string username = InputValidation.ValidateStringInput("Enter admin username");
            string password = InputValidation.GetHiddenPassword("Enter admin password");

            AdminAccount admin = adminManager.Search(username);

            if (admin != null && admin.Login(username, password))
            {
                Console.WriteLine("✅ Admin login successful. Redirecting to admin panel...");
                return admin;
            }
            else
            {
                Console.WriteLine("❌ Invalid credentials. Please try again.");
                return null;
            }
        }

    }
}