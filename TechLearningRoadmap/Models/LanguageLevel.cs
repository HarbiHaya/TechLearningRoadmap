using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using TechLearningRoadmap.Models;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Abstract base class representing a learning roadmap.
    /// Stores programming language-specific learning resources.
    /// </summary>
    public abstract class LanguageLevel
    {
        public Language LanguageType { get; private set; }
        public Level UserLevel { get; private set; }
        protected Dictionary<Level, string> LearningResources;

        /// <summary>
        /// Constructor to initialize language level.
        /// </summary>
        protected LanguageLevel(Language language, Level level)
        {
            LanguageType = language;
            UserLevel = level;
            LearningResources = new Dictionary<Level, string>();
            AssignRoadmap();
        }

        /// <summary>
        /// Abstract method to be implemented by subclasses to assign learning resources.
        /// </summary>
        protected abstract void AssignRoadmap();

        /// <summary>
        /// Retrieves the learning resource based on the user's level.
        /// </summary>
        public string GetLearningResource()
        {
            if (LearningResources.ContainsKey(UserLevel))
            {
                return LearningResources[UserLevel];
            }
            else
            {
                throw new InvalidOperationException("No resources available for the selected level.");
            }
        }


        /// <summary>
        /// Displays the assigned roadmap to the user.
        /// </summary>
        public void DisplayRoadmap()
        {
            try
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Programming Language: {LanguageType}");
                Console.WriteLine($"Experience Level: {UserLevel}");
                Console.WriteLine($"Recommended Resource: {GetLearningResource()}");
                Console.WriteLine("--------------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
