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
        /// Hashes the password using SHA-256.
        /// </summary>
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Updates the password securely.
        /// </summary>
        public void UpdatePassword(string newPassword)
        {
            SetPassword(newPassword);
            Console.WriteLine("Password has been updated successfully.");
        }

        /// <summary>
        /// Securely sets the password hash.
        /// </summary>
        private void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }

        /// <summary>
        /// Verifies user login by checking the password hash.
        /// </summary>
        public bool Login(string username, string password)
        {
            return Username == username && PasswordHash == HashPassword(password);
        }

        /// <summary>
        /// Displays account information (Implemented in derived classes).
        /// </summary>
        public abstract void DisplayInfo();
    }
}
