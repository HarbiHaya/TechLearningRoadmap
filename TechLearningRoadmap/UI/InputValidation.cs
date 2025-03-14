using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
// Haya Alharbi
// 2035768
// COCS307 - Assignment 1

namespace TechLearningRoadmap.UI
{
    public static class InputValidation
    {
        
      
        public static int ValidateMenuSelection(int min, int max) // this method is to ensure the input between the min and max for each menu we have 
        {
            int choice = min; // to avoid compile error 
            bool valid = false;

            do
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()?.Trim(); // to remove any white space

                try
                {
                    choice = int.Parse(input); //to convert the input to integer

                    if (choice < min || choice > max)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    valid = true;
                }
                catch (FormatException) // if the input is not a number 
                {
                    Console.WriteLine("Error: Invalid format. Please enter a number.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Error: Choice must be between {min} and {max}.");
                }

            } while (!valid);

            return choice;
        }

        public static string ValidateStringInput(string prompt) // this method is to ensure that input is not null
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

        // this method is to hide the password while typing it
        // was taken and modified from https://stackoverflow.com/questions/3404421/password-masking-console-application

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

        
        // to ensure that password meets requirements
        
        public static bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Error: Password cannot be empty.");
                return false;
            }

            if (password.Length < 8)
            {
                Console.WriteLine("Error: Password must be at least 8 characters long.");
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
                Console.WriteLine("Error: Password must contain at least one number.");
                return false;
            }

            if (!Regex.IsMatch(password, @"[\W_]")) // to check if the password contains any special character
            {
                Console.WriteLine(" Error: Password must contain at least one special character.");
                return false;
            }

            return true;
        }

        
        public static string GetValidatedPassword() // gets the validated password
        {
            string password;

            do
            {
                password = GetHiddenPassword("Enter a password"); 
            } while (!InputValidation.ValidatePassword(password)); 

            return password;
        }
    }
}
