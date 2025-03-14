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
    using System;
    using TechLearningRoadmap.Data;
    using TechLearningRoadmap.Models;
    using TechLearningRoadmap.Services;
    using TechLearningRoadmap.UI;

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            //  Ensure SINGLE instance of DataManager<T>
            DataManager<UserAccount> userManager = new DataManager<UserAccount>();
            DataManager<AdminAccount> adminManager = new DataManager<AdminAccount>();

            // ✅ Predefine Admin Accounts
            AdminAccount admin1 = new AdminAccount("jana", "JanaA123@");
            adminManager.Insert(admin1);

            AdminAccount admin2 = new AdminAccount("haya", "HayaA123@");
            adminManager.Insert(admin2);

            AdminAccount admin3 = new AdminAccount("shahad", "ShahadD123@");
            adminManager.Insert(admin3);

            AdminAccount admin4 = new AdminAccount("mayar", "MayarR123@");  
            adminManager.Insert(admin4);

            UserAccount user = new UserAccount("user", "User123@");
            userManager.Insert(user);

            UserAccount user2 = new UserAccount("user2", "User123@");
            userManager.Insert(user2);  


            //  Create Services
            AuthService authService = new AuthService(userManager, adminManager);
            RoadmapService roadmapService = new RoadmapService();
            Menu menu = new Menu(authService, roadmapService, userManager, adminManager);

            // ✅ Run the Program
            menu.DisplayMenu();
        }
    }

}
