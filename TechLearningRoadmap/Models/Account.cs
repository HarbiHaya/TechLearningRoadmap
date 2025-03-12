using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

using System;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Security.Cryptography;
using System.Text;

using System;
using System.Security.Cryptography;
using System.Text;

namespace TechLearningRoadmap.Models
{
    /// <summary>
    /// Represents a base account class for both users and admins.
    /// </summary>
    public abstract class Account
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }

        public Account(string username, string password)
        {
            Username = username;
            SetPassword(password); // Ensure password is always hashed at creation
        }

        /// <summary>
        /// Updates the password securely.
        /// </summary>
        public void UpdatePassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine(" Error: Password cannot be empty.");
                return;
            }

            SetPassword(newPassword);
            Console.WriteLine(" Password has been updated successfully.");
        }

        /// <summary>
        /// Verifies user login by checking the password hash.
        /// </summary>
        public bool Login(string username, string password)
        {
            if (Username == username && PasswordHash == HashPassword(password))
            {
                return true;
            }
            else
            {
                Console.WriteLine("❌ Error: Invalid username or password.");
                return false;
            }
        }

        /// sets password
       
        private void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }

        /// <summary>
        /// Hashes the password using SHA-256.
        /// </summary>
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

        /// <summary>
        /// Displays account information (Implemented in derived classes).
        /// </summary>
        public abstract void DisplayInfo();
    }
}
