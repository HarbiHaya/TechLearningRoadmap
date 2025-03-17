using TechLearningRoadmap.Models;
using TechLearningRoadmap.Services;
using TechLearningRoadmap.Data;

// Haya Alharbi
// 2035768
// COCS307 - Assignment 1

namespace TechLearningRoadmap.UI
{
   
    public class Menu
    {
        private AuthService authService;
        private RoadmapService roadmapService;
        private DataManager<UserAccount> userManager;
        private DataManager<AdminAccount> adminManager;

        public Menu(AuthService authService, RoadmapService roadmapService, DataManager<UserAccount> userManager, DataManager<AdminAccount> adminManager)
        {
            this.authService = authService;
            this.roadmapService = roadmapService;
            this.userManager = userManager;
            this.adminManager = adminManager;
        }


        // MAIN MENU 
        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Welcome to Tech Learning Roadmap ===");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Admin Login");
                Console.WriteLine("4. Exit");

                int choice = InputValidation.ValidateMenuSelection(1, 4);
                // using the AuthService to check for users and admins

                if (choice == 1) // registering new user 
                {
                    authService.RegisterUser();
                }
                else if (choice == 2) // logging in as a user 
                {
                    Account account = authService.LoginUser();
                    if (account is UserAccount user)
                    {
                        DisplayUserMenu(user);
                    }
                }
                else if (choice == 3) // logging in as an admin 
                {
                    Account admin = authService.LoginAdmin();
                    if (admin is AdminAccount adminAccount)
                    {
                        DisplayAdminMenu(adminAccount);
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                }
            }
        }

        // USER MENU
        private void DisplayUserMenu(UserAccount user)
        {
            while (true)
            {
                Console.WriteLine("\n=== User Dashboard ===");
                Console.WriteLine("1. Create My Roadmap");
                Console.WriteLine("2. View My Roadmap");
                Console.WriteLine("3. Change Learning Path");
                Console.WriteLine("4. Logout");

                int choice = InputValidation.ValidateMenuSelection(1, 4);

                if (choice == 1)
                {
                    Console.WriteLine("Let's create  your roadmap...");
                    user.UpdateLearningPreferences(); // This method is to both create and update update the user's learning preferences since its same implementation
                }
                else if (choice == 2)
                {
                    if (user.Language == Language.None || user.Level == Level.None) // checks if the user hasn't already created a roadmap and ask them to create one 
                    {
                        Console.WriteLine("No roadmap found! Please create one first.");
                    }
                    else
                    {
                        RoadmapService.GetRoadmap(user.Language, user.Level).DisplayRoadmap(); // if user have one , displays the roadmap for them (based on their language and level using Roadmapservice class)
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Updating your learning path."); // updates the user's learning path by asking the questions again
                    user.UpdateLearningPreferences();
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Logging out.");
                    break;
                }
            }
        }

        // ADMIN MENU
        private void DisplayAdminMenu(AdminAccount admin)
        {
            while (true)
            {
                Console.WriteLine("\n=== Admin Panel ===");
                Console.WriteLine("1. View All Users");
                Console.WriteLine("2. Manage Users");
                Console.WriteLine("3. Logout");

                int choice = InputValidation.ValidateMenuSelection(1, 3); // validates that admin's choice between min and max 

                if (choice == 1)
                {
                    admin.ListUsers(userManager); // sends the user manager to the admin to list all users using getAll method
                }
                else if (choice == 2)
                {
                    admin.ManageUsers(userManager); // for adding or removing users
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Logging out.");
                    break;
                }
            }
        }
    }
}
