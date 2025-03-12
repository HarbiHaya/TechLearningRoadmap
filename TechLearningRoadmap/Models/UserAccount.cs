using System;

using System;
using TechLearningRoadmap.Models;
using TechLearningRoadmap.Services;
using TechLearningRoadmap.UI;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents a standard user account in the system.
    /// </summary>
    public class UserAccount : Account
    {
        public Language Language { get; private set; }
        public Level Level { get; private set; }

        public UserAccount(string username, string password) : base(username, password)
        {
            // Default values for new users
            Language = Language.CSharp;
            Level = Level.Beginner;
        }

        /// <summary>
        /// Displays user account details.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"User: {Username}");
            Console.WriteLine($"Current Learning Path: {Language} ({Level})");
        }

        /// <summary>
        /// Allows the user to update their learning preferences.
        /// </summary>
        public void UpdateLearningPreferences()
        {
            Console.WriteLine("Choose a new programming language:");
            Console.WriteLine("1. C#\n2. Java\n3. Python");
            int langChoice = InputValidation.ValidateMenuSelection(1, 3);

            Language = langChoice switch
            {
                1 => Language.CSharp,
                2 => Language.Java,
                3 => Language.Python,
                _ => Language
            };

            Console.WriteLine("Select your experience level:");
            Console.WriteLine("1. Beginner\n2. Intermediate\n3. Advanced");
            int levelChoice = InputValidation.ValidateMenuSelection(1, 3);

            Level = levelChoice switch
            {
                1 => Level.Beginner,
                2 => Level.Intermediate,
                3 => Level.Advanced,
                _ => Level
            };

            Console.WriteLine($"Your learning path has been updated to {Language} ({Level}).");
        }
    }
}

