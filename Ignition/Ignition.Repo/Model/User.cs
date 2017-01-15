using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public User(String _username, String _password)
        {
            Username = _username;
            Password = _password;
        }
    }
}
