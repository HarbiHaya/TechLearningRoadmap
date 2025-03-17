using TechLearningRoadmap.Models;
using System.Collections;

// Mayar Mahfouz
// 2306450
// COCS307 - Assignment 1


namespace TechLearningRoadmap.Data
{
    // Generic class for managing user/admin accounts
    public class DataManager<T> : IDataManager<T>  where T : Account
    {
        private List<T> accounts; // a list that contains all accounts as objects
        private static ArrayList registeredUsernames = new ArrayList(); // storing usernames for easier search

        public DataManager()
        {
            accounts = new List<T>();
        }
        //  a method to check if a user exists by checking the username
        public bool UsernameExists(string username)
        {
          
            return registeredUsernames.Contains(username);
        }

        // inserts a new account into the system, ensuring no duplicate usernames
        public void Insert(T data)
        {
            if (UsernameExists(data.Username)) // checks username in ArrayList
            {
                Console.WriteLine("Error: Username already exists. Please choose a different username.");
                return;
            }

            accounts.Add(data); //  add account object to List<T>
            registeredUsernames.Add(data.Username); // add username in ArrayList
            Console.WriteLine($"Account '{data.Username}' successfully registered.");
        }

        // deletes a user account based on username
        public bool Delete(string username)
        {
            T accountToRemove = null;

            // Iterate through the list to find the matching account
            foreach (T account in accounts)
            {
                if (account.Username == username)
                {
                    accountToRemove = account;
                    break; // stop searching after the first accoint is found and assigns it to accountToRemove
                }
            }

            // If no matching account is found, return an error
            if (accountToRemove == null)
            {
                return false;
            }

            // ask for confirmation before deleting
            Console.Write($"Are you sure you want to delete '{username}'? (yes/no): ");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "yes")
            {
                accounts.Remove(accountToRemove); // remove the assigned value from the list
                registeredUsernames.Remove(username); // remove the username from the ArrayList
                return true;
            }
            else
            {
                return false;
            }
        }
        // Searches for a user account by username.
        public T Search(string username)
        {
            // iterate through the list to find the matching account
            foreach (T account in accounts)
            {
                if (account.Username == username)
                {
                    return account; // Return the first account that matches the username
                }
            }

            Console.WriteLine("User not found.");
            return null; // Return null if no match is found
        }


        // retrieves all registered accounts
        public List<T> GetAll()
        {
            return accounts; // returns the accounts list
        }


    }
}
