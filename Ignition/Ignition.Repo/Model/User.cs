using System;
using System.ComponentModel.DataAnnotations;

namespace Ignition.Repo.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string Password { get; set; }
        public int Role { get; set; }

        public User()
        {

        }

        public User(string _username, string _password)
        {
            Username = _username;
            Password = _password;
        }
    }
}
