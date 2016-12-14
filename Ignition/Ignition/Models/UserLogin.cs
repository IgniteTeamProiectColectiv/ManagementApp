using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignition.Models
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public UserLogin(String _username, String _password)
        {
            Username = _username;
            Password = _password;
        }

    }
}