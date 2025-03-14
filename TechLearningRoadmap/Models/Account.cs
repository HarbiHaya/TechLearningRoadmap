using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;



namespace TechLearningRoadmap.Models
{

    /// create  a new class
    public abstract class Account
    {
        private string username;
        private string password;

        public string Username
        {

            get
            {
                return username;
            }
            set
            {
                username = value;
            }

        }
        public string PasswordHash
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public Account(string username, string password)
        {
            Username = username;
            SetPassword(password); // Ensure  that password is always hashed at creation
        }

        /// Method for updating password 
        public void UpdatePassword(string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    throw new ArgumentException("Password cannot be empty.");
                }

                SetPassword(newPassword);
                Console.WriteLine("Password has been updated successfully.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Error: Password cannot be empty.");
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occurred.");
            }
        }

        /// logging in method 
        public bool Login(string username, string password)
        {
            if (Username == username && PasswordHash == HashPassword(password))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error: Invalid username or password.");
                return false;
            }
        }

        /// Method for setting password 

        private void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }

        /// making sure that password is hashed 
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// Create an abstract DisplayInfo method 
        public abstract void DisplayInfo();
    }
}
