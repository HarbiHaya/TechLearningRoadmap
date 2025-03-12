using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using TechLearningRoadmap.UI;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents an administrator account with user management capabilities.
    /// </summary>
    public class AdminAccount : Account
    {
        private List<UserAccount> managedUsers;

        public AdminAccount(string username, string password) : base(username, password)
        {
            managedUsers = new List<UserAccount>();
        }

        /// <summary>
        /// Displays admin account details.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Admin: {Username} (Has Management Privileges)");
        }

        /// <summary>
        /// Lists all users managed by the admin.
        /// </summary>
        public void ListUsers()
        {
            if (managedUsers.Count == 0)
            {
                Console.WriteLine("No users registered.");
                return;
            }

            Console.WriteLine("\n=== Registered Users ===");
            foreach (var user in managedUsers)
            {
                Console.WriteLine($"- {user.Username} | Learning: {user.Language} ({user.Level})");
            }
        }

        /// <summary>
        /// Allows the admin to add or remove users.
        /// </summary>
        public void ManageUsers()
        {
            while (true)
            {
                Console.WriteLine("\n=== User Management ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Remove User");
                Console.WriteLine("3. Back to Admin Panel");

                int choice = InputValidation.ValidateMenuSelection(1, 3);

                if (choice == 1)
                {
                    Console.Write("Enter username for new user: ");
                    string username = Console.ReadLine()?.Trim();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                    {
                        UserAccount newUser = new UserAccount(username, password);
                        managedUsers.Add(newUser);
                        Console.WriteLine($"User '{username}' added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Username and password cannot be empty.");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("Enter the username to remove: ");
                    string usernameToRemove = Console.ReadLine()?.Trim();

                    UserAccount userToRemove = managedUsers.Find(u => u.Username == usernameToRemove);
                    if (userToRemove != null)
                    {
                        managedUsers.Remove(userToRemove);
                        Console.WriteLine($"User '{usernameToRemove}' removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error: User not found.");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Returning to Admin Panel...");
                    break;
                }
            }
        }
    }
}
