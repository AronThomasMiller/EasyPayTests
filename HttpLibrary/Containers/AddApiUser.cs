using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary.Containers
{
    public class AddApiUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool Equals(UserData user)
        {
            return user.Name == Name && user.Email == Email && user.Password == Password;
        }
    }
}
