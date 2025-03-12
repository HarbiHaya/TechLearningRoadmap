using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLearningRoadmap.Models;

namespace TechLearningRoadmap.Data
{
    /// <summary>
    /// Generic data manager handling storage and operations for user accounts.
    /// Implements IDataManager<T> for structured CRUD operations.
    /// </summary>
    /// <typeparam name="T">Generic type parameter (UserAccount, AdminAccount, etc.).</typeparam>
    public class DataManager<T> : IDataManager<T> where T : Account
    {
        private List<T> accounts;

        public DataManager()
        {
            accounts = new List<T>();
        }

        /// <summary>
        /// Inserts a new account into the system, ensuring no duplicate usernames.
        /// </summary>
        public void Insert(T data)
        {
            if (accounts.Any(a => a.Username == data.Username))
            {
                Console.WriteLine("Error: Username already exists. Please choose a different username.");
                return;
            }

            accounts.Add(data);
            Console.WriteLine($"Account '{data.Username}' successfully registered.");
        }

        /// <summary>
        /// Deletes a user account based on the provided username.
        /// </summary>
        public bool Delete(string username)
        {
            T accountToRemove = accounts.FirstOrDefault(a => a.Username == username);

            if (accountToRemove == null)
            {
                Console.WriteLine("Error: User not found.");
                return false;
            }

            Console.Write($"Are you sure you want to delete '{username}'? (yes/no): ");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "yes")
            {
                accounts.Remove(accountToRemove);
                Console.WriteLine($"User '{username}' has been deleted.");
                return true;
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
                return false;
            }
        }

        /// <summary>
        /// Searches for a user account by username.
        /// </summary>
        public T Search(string username)
        {
            T account = accounts.FirstOrDefault(a => a.Username == username);

            if (account == null)
            {
                Console.WriteLine("User not found.");
                return null;
            }

            return account;
        }

        /// <summary>
        /// Allows a user to update their password securely.
        /// </summary>
        public bool Edit(string username, string newPassword)
        {
            T account = accounts.FirstOrDefault(a => a.Username == username);

            if (account == null)
            {
                Console.WriteLine("Error: User not found.");
                return false;
            }

            if (!ValidatePassword(newPassword))
            {
                Console.WriteLine("Error: Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a digit, and a special character.");
                return false;
            }

            account.UpdatePassword(newPassword);
            Console.WriteLine($"Password updated successfully for user '{username}'.");
            return true;
        }

        /// <summary>
        /// Retrieves all registered accounts.
        /// </summary>
        public List<T> GetAll()
        {
            return accounts;
        }

        /// <summary>
        /// Validates password security requirements.
        /// </summary>
        private bool ValidatePassword(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}

