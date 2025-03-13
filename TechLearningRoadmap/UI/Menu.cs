using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechLearningRoadmap.Models;
using TechLearningRoadmap.Services;
using TechLearningRoadmap.Data;

namespace TechLearningRoadmap.UI
{
    /// <summary>
    /// Manages the main menu and user interactions.
    /// </summary>
    using System;


    namespace TechLearningRoadmap.UI
    {
        /// <summary>
        /// Manages the main menu and user interactions.
        /// </summary>
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

            /// <summary>
            /// Displays the main menu and handles user selections.
            /// </summary>
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

                    if (choice == 1)
                    {
                        authService.RegisterUser();
                    }
                    else if (choice == 2)
                    {
                        Account account = authService.LoginUser();
                        if (account is UserAccount user)
                        {
                            DisplayUserMenu(user);
                        }
                    }
                    else if (choice == 3)
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

            /// <summary>
            /// Displays the user dashboard menu.
            /// </summary>
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
                        Console.WriteLine("Let's create or find your roadmap...");
                        user.UpdateLearningPreferences(); // ✅ Allows user to choose language & level
                    }
                    else if (choice == 2)
                    {
                        if (user.Language == Language.None || user.Level == Level.None)
                        {
                            Console.WriteLine("❌ No roadmap found! Please create one first.");
                        }
                        else
                        {
                            RoadmapService.GetRoadmap(user.Language, user.Level).DisplayRoadmap();
                        }
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Updating your learning path...");
                        user.UpdateLearningPreferences();
                    }
                    else if (choice == 4)
                    {
                        Console.WriteLine("Logging out...");
                        break;
                    }
                }
            }

            /// <summary>
            /// Displays the admin dashboard menu.
            /// </summary>
            private void DisplayAdminMenu(AdminAccount admin)
            {
                while (true)
                {
                    Console.WriteLine("\n=== Admin Panel ===");
                    Console.WriteLine("1. View All Users");
                    Console.WriteLine("2. Manage Users");
                    Console.WriteLine("3. Logout");

                    int choice = InputValidation.ValidateMenuSelection(1, 3);

                    if (choice == 1)
                    {
                        admin.ListUsers(userManager); // ✅ Fix: Pass userManager
                    }
                    else if (choice == 2)
                    {
                        admin.ManageUsers(userManager);
                    }
                    else if (choice == 3)
                    {
                        Console.WriteLine("Logging out...");
                        break;
                    }
                }
            }
        }
    }
}
