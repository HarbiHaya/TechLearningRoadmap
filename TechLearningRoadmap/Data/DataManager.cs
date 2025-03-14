using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLearningRoadmap.Models;
using System;
using System.Collections;
using System.Linq;
using TechLearningRoadmap.UI;

namespace TechLearningRoadmap.Data
{
    /// <summary>
    /// Generic data manager for handling user and admin accounts
    /// </summary>
    /// <typeparam name="T">Type parameter constrained to Account.</typeparam>
    public class DataManager<T> : IDataManager<T> where T : Account
    {
        private ArrayList accounts; // ✅ Changed from List<T> to ArrayList

        public DataManager()
        {
            accounts = new ArrayList(); // ✅ Explicitly initialize ArrayList
        }

        /// <summary>
        /// Inserts a new account into the system, ensuring no duplicate usernames.
        /// </summary>
        public void Insert(T data)
        {
            bool usernameExists = false;

            foreach (T account in accounts.Cast<T>()) //  Cast ArrayList before looping
            {
                if (account.Username == data.Username)
                {
                    usernameExists = true;
                    break;
                }
            }

            if (usernameExists)
            {
                Console.WriteLine("Error: Username already exists. Please choose a different username.");
                return;
            }

            accounts.Add(data);
            Console.WriteLine($"✅ Account '{data.Username}' successfully registered.");
        }

        /// <summary>
        /// Deletes a user account based on username.
        /// </summary>
        public bool Delete(string username)
        {
            T accountToRemove = null;

            foreach (T account in accounts.Cast<T>()) // ✅ Cast ArrayList before iterating
            {
                if (account.Username == username)
                {
                    accountToRemove = account;
                    break;
                }
            }

            if (accountToRemove == null)
            {
                Console.WriteLine("❌ Error: User not found.");
                return false;
            }

            Console.Write($"Are you sure you want to delete '{username}'? (yes/no): ");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "yes")
            {
                accounts.Remove(accountToRemove);
                Console.WriteLine($"✅ User '{username}' has been deleted.");
                return true;
            }
            else
            {
                Console.WriteLine("🚫 Operation cancelled.");
                return false;
            }
        }

        /// <summary>
        /// Searches for a user account by username.
        /// </summary>
        public T Search(string username)
        {
            foreach (T account in accounts.Cast<T>()) // ✅ Cast ArrayList before searching
            {
                if (account.Username == username)
                {
                    return account;
                }
            }

            Console.WriteLine("❌ User not found.");
            return null;
        }

        /// <summary>
        /// Allows a user to update their password securely.
        /// </summary>
        public bool Edit(string username, string newPassword)
        {
            T accountToEdit = null;

            foreach (T account in accounts.Cast<T>()) // ✅ Cast ArrayList before iterating
            {
                if (account.Username == username)
                {
                    accountToEdit = account;
                    break;
                }
            }

            if (accountToEdit == null)
            {
                Console.WriteLine("❌ Error: User not found.");
                return false;
            }

            if (!InputValidation.ValidatePassword(newPassword))
            {
                Console.WriteLine("❌ Error: Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a digit, and a special character.");
                return false;
            }

            accountToEdit.UpdatePassword(newPassword);
            Console.WriteLine($"✅ Password updated successfully for user '{username}'.");
            return true;
        }

        /// <summary>
        /// Retrieves all registered accounts.
        /// </summary>
        public ArrayList GetAll()
        {
            return accounts; // ✅ Always returns the shared `ArrayList`
        }


    }
}
