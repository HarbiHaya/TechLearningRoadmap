using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace TechLearningRoadmap.UI
{
    /// <summary>
    /// Handles input validation to ensure correct user selections.
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Validates numeric menu input.
        /// </summary>
        public static int ValidateMenuSelection(int min, int max)
        {
            while (true)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()?.Trim();

                if (int.TryParse(input, out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine($"Invalid choice. Please enter a number between {min} and {max}.");
                }
            }
        }

        /// <summary>
        /// Validates non-empty string input.
        /// </summary>
        public static string ValidateStringInput(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            }
        }
    }
}

