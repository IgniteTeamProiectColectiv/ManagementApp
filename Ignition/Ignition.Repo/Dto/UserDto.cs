using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignition.Repo.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public UserDto() { }

        public UserDto(String _username, String _password)
        {
            Username = _username;
            Password = _password;
        }

    }
}
