using TechLearningRoadmap.Data;
using TechLearningRoadmap.UI;

// Jana Alharbi
// 2305762
// COCS307 - Assignment 1

namespace TechLearningRoadmap.Models

{
    /// Creating Admin accont that inherits from abstract Account class 
    public class AdminAccount : Account
    {
        public AdminAccount(string username, string password) : base(username, password) { }



        ///Method implemented from parent class 
        public override void DisplayInfo()
        {
            Console.WriteLine($" Admin: {Username} "); // hasnt been actually used in the program 
        }


        // list users with theit learning preferences
        public void ListUsers(DataManager<UserAccount> userManager)
        {
            List<UserAccount> allUsers = userManager.GetAll(); // Directly retrieve as List<UserAccount> 

            if (allUsers.Count == 0)
            {
                Console.WriteLine("No users registered.");
                return;
            }

            Console.WriteLine("\n=== Registered Users ===");
            foreach (UserAccount user in allUsers) 
            {
                Console.WriteLine($" {user.Username} | Learning: {user.Language} ({user.Level})"); 
            }
        }

        // menu for managing users
        public void ManageUsers(DataManager<UserAccount> userManager) 
        {
            while (true)
            {
                Console.WriteLine("\n===   User Management ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Remove User");
                Console.WriteLine("3. Back to Admin Panel");

                int choice = InputValidation.ValidateMenuSelection(1, 3);

                if (choice == 1)
                {
                    AddUser(userManager);
                }
                else if (choice == 2)
                {
                    RemoveUser(userManager);
                }
                else if (choice == 3)
                {
                    Console.WriteLine(" Back to Admin Panel");
                    break;
                }
            }
        }


        /// Method for adding users 
        private void AddUser(DataManager<UserAccount> userManager)
        {
            string username;
            string password;

            while (true)
            {
                Console.Write("Enter username for new user: ");
                username = Console.ReadLine().Trim(); // trim to remove whitespaces

                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("Error: Username cannot be empty. Please enter a valid username.");
                    continue;
                }

                if (userManager.UsernameExists(username))
                {
                    Console.WriteLine("Error: Username is taken. Please enter a different username.");
                    continue;
                }

                break;
            }

            password = InputValidation.GetValidatedPassword();
            UserAccount newUser = new UserAccount(username, password);
            userManager.Insert(newUser);
           
        }


        /// Method Removing users 
        private void RemoveUser(DataManager<UserAccount> userManager)
        {
            Console.Write("Enter the username to remove: ");
            string usernameToRemove = Console.ReadLine().Trim();

            if (!userManager.UsernameExists(usernameToRemove))
            {
                Console.WriteLine("Error: User not found.");
                return;
            }

            if (userManager.Delete(usernameToRemove))
            {
                Console.WriteLine($"User '{usernameToRemove}' removed successfully.");
            }
            else
            {
                Console.WriteLine("Error: Unable to remove the user.");
            }
        }



    }
}
