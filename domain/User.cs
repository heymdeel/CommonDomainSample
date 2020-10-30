using System;
using System.ComponentModel.DataAnnotations;

namespace domain
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public int RoleId { get; set; }
    }
}
