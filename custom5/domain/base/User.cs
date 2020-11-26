using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace custom5
{
    public interface IUser { }

    public abstract class User<TTest, TRole> : IUser
        where TRole : IRole
        where TTest : ITest
    {
        public TRole Role { get; set; }

        public TTest Test { get; set; }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }
    }
}
