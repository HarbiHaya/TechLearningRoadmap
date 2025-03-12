using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace TechLearningRoadmap.Data
{
    /// <summary>
    /// Interface defining CRUD operations for data management.
    /// Uses generics for flexibility in handling different data types.
    /// </summary>
    /// <typeparam name="T">Generic type representing stored entities.</typeparam>
    public interface IDataManager<T>
    {
        void Insert(T data);
        bool Delete(string username);
        T Search(string username);
        bool Edit(string username, string newPassword);
        List<T> GetAll();
    }
}
