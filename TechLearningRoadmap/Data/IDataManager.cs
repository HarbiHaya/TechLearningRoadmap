
using TechLearningRoadmap.Models;

// Mayar Mahfouz
// 2306450
// COCS307 - Assignment 1

namespace TechLearningRoadmap.Data
{

    // Generic interface for managing user and admin accounts
    public interface IDataManager<T> where T : Account // restriction to account class 
    {
        // checks if a username exists
        bool UsernameExists(string username);

        // Inserts a new account 
        void Insert(T data);

        // Deletes a user account based on username
        bool Delete(string username);

        // Edits a user account's username
        public bool EditUsername(string oldUsername, string newUsername);

        // Searches for a user account by username
        T Search(string username);


        // retrieves all registered accounts
        List<T> GetAll(); 
    }
}
