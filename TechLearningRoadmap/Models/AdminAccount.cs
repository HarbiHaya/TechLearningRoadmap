using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using TechLearningRoadmap.UI;

using System;
using System.Collections;
using TechLearningRoadmap.Data;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents an administrator account with user management capabilities.
    /// </summary>
    public class AdminAccount : Account
    {
        public AdminAccount(string username, string password) : base(username, password) { }

        /// <summary>
        /// Displays admin account details.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"👨‍💼 Admin: {Username} (Has Management Privileges)");
        }

        /// <summary>
        /// Lists all registered users in the system.
        /// </summary>
        public void ListUsers(DataManager<UserAccount> userManager)
        {
            ArrayList allUsers = userManager.GetAll();

            if (allUsers.Count == 0)
            {
                Console.WriteLine("⚠ No users registered.");
                return;
            }

            Console.WriteLine("\n=== 📋 Registered Users ===");
            foreach (object obj in allUsers)
            {
                if (obj is UserAccount user)
                {
                    Console.WriteLine($"🔹 {user.Username} | Learning: {user.Language} ({user.Level})");
                }
            }
        }

        /// <summary>
        /// Allows the admin to manage users (Add/Remove).
        /// </summary>
        public void ManageUsers(DataManager<UserAccount> userManager)
        {
            while (true)
            {
                Console.WriteLine("\n=== 🛠 User Management ===");
                Console.WriteLine("1️⃣ Add User");
                Console.WriteLine("2️⃣ Remove User");
                Console.WriteLine("3️⃣ Back to Admin Panel");

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
                    Console.WriteLine("🔙 Returning to Admin Panel...");
                    break;
                }
            }
        }

        /// <summary>
        /// Handles adding a new user.
        /// </summary>
        private void AddUser(DataManager<UserAccount> userManager)
        {
            string username, password;

            while (true)
            {
                Console.Write("👤 Enter username for new user: ");
                username = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(username))
                {
                    Console.WriteLine("❌ Error: Username cannot be empty. Please enter a valid username.");
                    continue;
                }

                if (userManager.Search(username) != null)
                {
                    Console.WriteLine("❌ Error: Username already exists. Choose a different one.");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("🔑 Enter password: ");
                password = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("❌ Error: Password cannot be empty. Please enter a valid password.");
                    continue;
                }

                if (!InputValidation.ValidatePassword(password))
                {
                    Console.WriteLine("❌ Error: Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a digit, and a special character.");
                    continue;
                }

                break;
            }

            // ✅ Create and add user
            UserAccount newUser = new UserAccount(username, password);
            userManager.Insert(newUser);
            Console.WriteLine($"✅ User '{username}' added successfully.");
        }

        /// <summary>
        /// Handles removing a user.
        /// </summary>
        private void RemoveUser(DataManager<UserAccount> userManager)
        {
            Console.Write("🗑 Enter the username to remove: ");
            string usernameToRemove = Console.ReadLine()?.Trim();

            ArrayList allUsers = userManager.GetAll();
            UserAccount userToRemove = null;

            foreach (object obj in allUsers)
            {
                if (obj is UserAccount user && user.Username.Equals(usernameToRemove, StringComparison.OrdinalIgnoreCase))
                {
                    userToRemove = user;
                    break;
                }
            }

            if (userToRemove == null)
            {
                Console.WriteLine("❌ Error: User not found.");
                return;
            }

            userManager.Delete(usernameToRemove);
            Console.WriteLine($"✅ User '{usernameToRemove}' removed successfully.");
        }


    }
}
