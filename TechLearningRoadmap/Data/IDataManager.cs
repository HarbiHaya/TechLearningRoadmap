using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using TechLearningRoadmap.Models;

namespace TechLearningRoadmap.Data
{

    /// Generic interface for managing user/admin accounts
    public interface IDataManager<T> where T : Account
    {
        // checks if a username exists
        bool UsernameExists(string username);

        /// Inserts a new account into the system.
        void Insert(T data);

        /// Deletes a user account based on username.
        bool Delete(string username);

        /// Searches for a user account by username.
        T Search(string username);


        /// Retrieves all registered accounts.
        List<T> GetAll(); // ✅ Changed from List<T> to ArrayList
    }
}
