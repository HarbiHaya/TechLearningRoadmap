using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TechLearningRoadmap.UI
{
    public static class InputValidation
    {
        /// <summary>
        /// Ensures numeric input falls within a valid menu selection range.
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
                    Console.WriteLine($"❌ Error: Please enter a number between {min} and {max}.");
                }
            }
        }

        /// <summary>
        /// Ensures non-empty string input.
        /// </summary>
        public static string ValidateStringInput(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("❌ Error: Input cannot be empty. Please try again.");
                }
            }
        }

        /// <summary>
        /// Captures password input securely, masking it with '*'.
        /// </summary>
        public static string GetHiddenPassword(string prompt)
        {
            Console.Write($"{prompt}: ");
            string password = "";
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true); // Read key without displaying it

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine(); // Move to next line after pressing Enter
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[..^1]; // Remove last character
                    Console.Write("\b \b"); // Erase character on screen
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*"); // Display '*' instead of actual character
                }
            }

            return password;
        }

        /// <summary>
        /// Ensures the password meets security standards and provides user feedback.
        /// </summary>
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("❌ Error: Password cannot be empty.");
                return false;
            }

            if (password.Length < 8)
            {
                Console.WriteLine("❌ Error: Password must be at least 8 characters long.");
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("❌ Error: Password must contain at least one uppercase letter.");
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                Console.WriteLine("❌ Error: Password must contain at least one lowercase letter.");
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("❌ Error: Password must contain at least one number.");
                return false;
            }

            if (!Regex.IsMatch(password, @"[\W_]")) // Matches special characters
            {
                Console.WriteLine("❌ Error: Password must contain at least one special character (@, #, !, $, etc.).");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Captures and validates a password with retry attempts.
        /// </summary>
        public static string GetValidatedPassword()
        {
            while (true)
            {
                string password = GetHiddenPassword("Enter a secure password (min 8 chars, 1 uppercase, 1 lowercase, 1 digit, 1 special char)");

                if (ValidatePassword(password))
                {
                    return password;
                }

                Console.WriteLine("⚠️ Please enter a valid password that meets all requirements.");
            }
        }
    }
}
