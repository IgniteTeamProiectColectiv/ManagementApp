using System;

namespace Ignition.Models
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLogin() { }

        public UserLogin(string _username, string _password)
        {
            Username = _username;
            Password = _password;
        }
    }
}