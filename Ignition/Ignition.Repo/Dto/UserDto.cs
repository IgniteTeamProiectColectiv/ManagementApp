using System;

namespace Ignition.Repo.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public UserDto() { }

        public UserDto(string _username, string _password)
        {
            Username = _username;
            Password = _password;
        }

    }
}
