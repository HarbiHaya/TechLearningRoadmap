

using System;
using System.Collections;
using System.Collections.Generic;
using TechLearningRoadmap.Data;
using TechLearningRoadmap.UI;


namespace TechLearningRoadmap.Models

{
    /// Creating Admin accont that inherits from abstract Account class 
    public class AdminAccount : Account
    {
        public AdminAccount(string username, string password) : base(username, password) { }



        ///Method implemented from parent class 
        public override void DisplayInfo()
        {
            Console.WriteLine($" Admin: {Username} (Has Management Privileges)");
        }


        public void ListUsers(DataManager<UserAccount> userManager)
        {
            List<UserAccount> allUsers = userManager.GetAll(); // Directly retrieve as List<UserAccount>

            if (allUsers.Count == 0)
            {
                Console.WriteLine("No users registered.");
                return;
            }

            Console.WriteLine("\n=== Registered Users ===");
            foreach (UserAccount user in allUsers) // Direct iteration, no casting needed
            {
                Console.WriteLine($" {user.Username} | Learning: {user.Language} ({user.Level})");
            }
        }

        public void ManageUsers(DataManager<UserAccount> userManager)
        {
            while (true)
            {
                Console.WriteLine("\n===   User Management ===");
                Console.WriteLine("1️ Add User");
                Console.WriteLine("2️ Remove User");
                Console.WriteLine("3️ Back to Admin Panel");

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
                    Console.WriteLine(" Returning to Admin Panel...");
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
        username = Console.ReadLine().Trim();

        if (string.IsNullOrEmpty(username))
        {
            Console.WriteLine("Error: Username cannot be empty. Please enter a valid username.");
            continue;
        }

        if (userManager.UsernameExists(username))
        {
            continue;
        }

        break;
    }

    password = InputValidation.GetValidatedPassword();
    UserAccount newUser = new UserAccount(username, password);
    userManager.Insert(newUser);
    Console.WriteLine($"User '{username}' added successfully.");
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
