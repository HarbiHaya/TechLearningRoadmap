﻿using TechLearningRoadmap.UI;

// Jana Alharbi
// 2305762
// COCS307 - Assignment 1


namespace TechLearningRoadmap.Models
{
    /// creating a UserAccount class that inherits from Account class
    public class UserAccount : Account
    {
        public Language Language { get; private set; }
        public Level Level { get; private set; }

        public UserAccount(string username, string password) : base(username, password)
        {
            // Default values 
            Language = Language.None;
            Level = Level.None;
        }

        /// overridden method from parent class 
        public override void DisplayInfo()
        {
            string languageText;
            if (Language == Language.None)
            {
                languageText = "Not Set";
            }
            else
            {
                languageText = Language.ToString();
            }

            string levelText;
            if (Level == Level.None)
            {
                levelText = "Not Set";
            }
            else
            {
                levelText = Level.ToString();
            }

            Console.WriteLine("User: " + Username);
            Console.WriteLine("Current Learning Path: " + languageText + " (" + levelText + ")");
        }

        /// Method for updating users Learning Preferences
        public void UpdateLearningPreferences()
        {
            Console.WriteLine("Choose a programming language:");
            Console.WriteLine("1. C#\n2. Java\n3. Python");
            int langChoice = InputValidation.ValidateMenuSelection(1, 3);

            if (langChoice == 1)
            {
                Language = Language.CSharp;
            }
            else if (langChoice == 2)
            {
                Language = Language.Java;
            }
            else if (langChoice == 3)
            {
                Language = Language.Python;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine("Select your experience level:");
            Console.WriteLine("1. Beginner\n2. Intermediate\n3. Advanced");
            int levelChoice = InputValidation.ValidateMenuSelection(1, 3);

            if (levelChoice == 1)
            {
                Level = Level.Beginner;
            }
            else if (levelChoice == 2)
            {
                Level = Level.Intermediate;
            }
            else if (levelChoice == 3)
            {
                Level = Level.Advanced;
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            Console.WriteLine($"Your learning path has been set: {Language} ({Level})");
        }
    }
}

