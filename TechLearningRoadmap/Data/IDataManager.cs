using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using TechLearningRoadmap.Models;

namespace TechLearningRoadmap.Data
{
    /// <summary>
    /// Generic interface for managing user/admin accounts
    /// </summary>
    public interface IDataManager<T> where T : Account
    {
        /// <summary>
        /// Inserts a new account into the system.
        /// </summary
        void Insert(T data);

        /// <summary>
        /// Deletes a user account based on username.
        /// </summary>
        bool Delete(string username);

        /// <summary>
        /// Searches for a user account by username.
        /// </summary>
        T Search(string username);

        /// <summary>
        /// Allows a user to update their password securely.
        /// </summary>
        bool Edit(string username, string newPassword);

        /// <summary>
        /// Retrieves all registered accounts.
        /// </summary>
        List<T> GetAll(); // ✅ Changed from List<T> to ArrayList
    }
}
