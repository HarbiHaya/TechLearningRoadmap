
using TechLearningRoadmap.Models;
using TechLearningRoadmap.UI;
using TechLearningRoadmap.Services;
using TechLearningRoadmap.Data;


// COCS307 - Assignment 1

namespace TechLearningRoadmap
{

    class Program
    {
        static void Main() { 

            DataManager<UserAccount> userManager = new DataManager<UserAccount>();
            DataManager<AdminAccount> adminManager = new DataManager<AdminAccount>();

            // predefine admin accounts
            // for testing purposes we added some admin accounts 

            AdminAccount admin = new AdminAccount("maryam", "MaryamM123@");
            adminManager.Insert(admin);

            AdminAccount admin1 = new AdminAccount("jana", "JanaA123@");
            adminManager.Insert(admin1);

            AdminAccount admin2 = new AdminAccount("haya", "HayaA123@");
            adminManager.Insert(admin2);

            AdminAccount admin3 = new AdminAccount("shahad", "ShahadD123@");
            adminManager.Insert(admin3);

            AdminAccount admin4 = new AdminAccount("mayar", "MayarR123@");
            adminManager.Insert(admin4);

            // some users for an easier manipulating :) 

            UserAccount user = new UserAccount("user", "User123@");
            userManager.Insert(user);

            UserAccount user2 = new UserAccount("user2", "User123@");
            userManager.Insert(user2);


            // getting services ready to be used  
            AuthService authService = new AuthService(userManager, adminManager);
            RoadmapService roadmapService = new RoadmapService();

            // menus too 
            Menu menu = new Menu(authService, roadmapService, userManager, adminManager);

            // Program now starts
            menu.DisplayMenu();



        }
    }

}
