using System.Security.Cryptography; // for hashing method 
using System.Text;

// Jana Alharbi
// 2305762
// COCS307 - Assignment 1

namespace TechLearningRoadmap.Models
{

    // create  a new class
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
        
       

        // logging in method 
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

        // Method for setting password 

        private void SetPassword(string password)
        {
            PasswordHash = HashPassword(password);
        }

        // making sure that password is hashed 
        // this methids has been taken and modified from https://stackoverflow.com/questions/12416249/hashing-a-string-with-sha256
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

        public abstract void DisplayInfo();
    }
}
