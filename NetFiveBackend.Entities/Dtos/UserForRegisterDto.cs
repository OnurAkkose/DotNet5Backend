using CAFEMENU.Core.Entities;
using System;
using System.Linq;

namespace CAFEMENU.Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
