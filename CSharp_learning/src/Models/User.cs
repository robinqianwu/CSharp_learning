using System;

namespace CSharp_learning.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool ValidateCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}