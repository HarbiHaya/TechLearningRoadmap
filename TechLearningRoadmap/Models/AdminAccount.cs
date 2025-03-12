using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using TechLearningRoadmap.UI;

using System;
using System.Collections.Generic;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents an administrator account with user management capabilities.
    /// </summary>
    public class AdminAccount : Account
    {
        private List<UserAccount> managedUsers; // ✅ List of managed users

        public AdminAccount(string username, string password) : base(username, password)
        {
            managedUsers = new List<UserAccount>();
        }

        /// <summary>
        /// Displays admin account details.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"👨‍💼 Admin: {Username} (Has Management Privileges)");
        }

        /// <summary>
        /// Lists all users managed by the admin.
        /// </summary>
        public void ListUsers()
        {
            if (managedUsers.Count == 0)
            {
                Console.WriteLine("⚠ No users registered.");
                return;
            }

            Console.WriteLine("\n=== 📋 Registered Users ===");
            foreach (var user in managedUsers)
            {
                Console.WriteLine($"🔹 {user.Username} | Learning: {user.Language} ({user.Level})");
            }
        }

        /// <summary>
        /// Allows the admin to manage users (Add/Remove).
        /// </summary>
        public void ManageUsers()
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
                    AddUser();
                }
                else if (choice == 2)
                {
                    RemoveUser();
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
        private void AddUser()
        {
            Console.Write("👤 Enter username for new user: ");
            string username = Console.ReadLine()?.Trim();
            Console.Write(" Enter password: ");
            string password = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("❌ Error: Username and password cannot be empty.");
                return;
            }

            UserAccount newUser = new UserAccount(username, password);
            managedUsers.Add(newUser);
            Console.WriteLine($"✅ User '{username}' added successfully.");
        }

        /// <summary>
        /// Handles removing a user.
        /// </summary>
        private void RemoveUser()
        {
            Console.Write("🗑 Enter the username to remove: ");
            string usernameToRemove = Console.ReadLine()?.Trim();

            UserAccount userToRemove = managedUsers.Find(u => u.Username == usernameToRemove);

            if (userToRemove == null)
            {
                Console.WriteLine("❌ Error: User not found.");
                return;
            }

            managedUsers.Remove(userToRemove);
            Console.WriteLine($"✅ User '{usernameToRemove}' removed successfully.");
        }
    }
}
