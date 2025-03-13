using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System;
using System.Linq;
using System.Text.RegularExpressions;

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TechLearningRoadmap.UI
{
    public static class InputValidation
    {
        /// <summary>
        /// Ensures numeric input falls within a specified menu selection range.
        /// </summary>
        public static int ValidateMenuSelection(int min, int max)
        {
            int choice = min; // Default value to avoid compile error 
            bool valid = false;

            do
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()?.Trim();

                try
                {
                    choice = int.Parse(input);

                    if (choice < min || choice > max)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    valid = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ Error: Invalid format. Please enter a number.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"❌ Error: Choice must be between {min} and {max}.");
                }

            } while (!valid);

            return choice;
        }


        /// <summary>
        /// Ensures user input is a non-empty string.
        /// </summary>
        public static string ValidateStringInput(string prompt)
        {
            string input;
            do
            {
                Console.Write($"{prompt}: ");
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Error: Input cannot be empty. Try again.");
                }

            } while (string.IsNullOrWhiteSpace(input));

            return input;
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
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }

            return password;
        }

        /// <summary>
        /// Ensures the password meets security standards.
        /// </summary>
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine(" Error: Password cannot be empty.");
                return false;
            }

            if (password.Length < 8)
            {
                Console.WriteLine(" Error: Password must be at least 8 characters long.");
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Error: Password must contain at least one uppercase letter.");
                return false;
            }

            if (!password.Any(char.IsLower))
            {
                Console.WriteLine("Error: Password must contain at least one lowercase letter.");
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine(" Error: Password must contain at least one number.");
                return false;
            }

            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                Console.WriteLine(" Error: Password must contain at least one special character.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Captures and validates a password.
        /// </summary>
        public static string GetValidatedPassword()
        {
            string password;

            do
            {
                password = GetHiddenPassword("Enter a secure password");
            } while (!InputValidation.ValidatePassword(password));

            return password;
        }
    }
}
