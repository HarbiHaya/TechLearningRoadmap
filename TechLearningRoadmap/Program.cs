using System;
using TechLearningRoadmap.Models;

using System;
using TechLearningRoadmap.UI;
 using TechLearningRoadmap.Services;
using TechLearningRoadmap.Data;
using TechLearningRoadmap.UI.TechLearningRoadmap.UI;
class Program
{
    static void Main()
    {
        // Initialize Data Managers
        var userManager = new DataManager<UserAccount>();
        var adminManager = new DataManager<AdminAccount>();

        // Create a default admin account if none exists
        if (adminManager.GetAll().Count == 0)
        {
            adminManager.Insert(new AdminAccount("admin", "Admin@123"));
            Console.WriteLine("Default admin account created (Username: admin, Password: Admin@123)");
        }

        // Initialize Services
        var authService = new AuthService(userManager, adminManager);
        var roadmapService = new RoadmapService();

        // Initialize Menu System
        var menu = new Menu(authService, roadmapService, userManager, adminManager);

        // Start the Application
        menu.DisplayMenu();
    }
}
