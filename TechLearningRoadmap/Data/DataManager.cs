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
        private List<T> accounts;
        private static ArrayList registeredUsernames = new ArrayList(); // ✅ Stores usernames separately

        public DataManager()
        {
            accounts = new List<T>();
        }
        public bool UsernameExists(string username)
        {
            //   method to check if a user exists
            return registeredUsernames.Contains(username);
        }
        // Inserts a new account into the system, ensuring no duplicate usernames.

        public void Insert(T data)
        {
            if (UsernameExists(data.Username)) // ✅ Check username in ArrayList
            {
                Console.WriteLine("Error: Username already exists. Please choose a different username.");
                return;
            }

            accounts.Add(data); //  Add account object to List<T>
            registeredUsernames.Add(data.Username); // add username in ArrayList
            Console.WriteLine($"Account '{data.Username}' successfully registered.");
        }

        /// <summary>
        /// Deletes a user account based on username.
        /// </summary>
        public bool Delete(string username)
        {
            T accountToRemove = null;

            // Iterate through the list to find the matching account
            foreach (T account in accounts)
            {
                if (account.Username == username)
                {
                    accountToRemove = account;
                    break; // Stop searching after the first match
                }
            }

            // If no matching account is found, return an error
            if (accountToRemove == null)
            {
                return false;
            }

            // Ask for confirmation before deleting
            Console.Write($"Are you sure you want to delete '{username}'? (yes/no): ");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "yes")
            {
                accounts.Remove(accountToRemove); // Remove from the list
                return true;
            }
            else
            {
                return false;
            }
        }
        /// Searches for a user account by username.
        public T Search(string username)
        {
            // Iterate through the list to find the matching account
            foreach (T account in accounts)
            {
                if (account.Username == username)
                {
                    return account; // Return the first matching account
                }
            }

            Console.WriteLine("User not found.");
            return null; // Return null if no match is found
        }

      
        /// Retrieves all registered accounts.
        public List<T> GetAll()
        {
            return accounts; // ✅ Always returns the shared `ArrayList`
        }


    }
}
