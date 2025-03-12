using System;
using TechLearningRoadmap.Models;

using System;
using TechLearningRoadmap.UI;
 using TechLearningRoadmap.Services;
using TechLearningRoadmap.Data;
using TechLearningRoadmap.UI.TechLearningRoadmap.UI;
using System;


namespace TechLearningRoadmap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🔹 Tech Learning Roadmap System 🔹");

            // Initialize Data Managers
            DataManager<UserAccount> userManager = new DataManager<UserAccount>();
            DataManager<AdminAccount> adminManager = new DataManager<AdminAccount>();

            // Predefined Admin Account
            AdminAccount admin1 = new AdminAccount("jana", "JanaA123@");
            adminManager.Insert(admin1);

            AdminAccount admin2 = new AdminAccount("haya", "HayaA123@");
            adminManager.Insert(admin1);

            AdminAccount admin3 = new AdminAccount("shahad", "ShahadD123@");
            adminManager.Insert(admin1);

            AdminAccount admin4 = new AdminAccount("mayar", "MayarR123@");
            adminManager.Insert(admin1);


            // Initialize Services
            AuthService authService = new AuthService(userManager, adminManager);
            RoadmapService roadmapService = new RoadmapService();
            Menu menu = new Menu(authService, roadmapService, userManager, adminManager);

            // ✅ Start Main Menu
            menu.DisplayMenu();
        }
    }
}
