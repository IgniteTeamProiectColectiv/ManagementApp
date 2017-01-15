using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignition.Models
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLogin() { }

        public UserLogin(String _username, String _password)
        {
            Username = _username;
            Password = _password;
        }
    }
}