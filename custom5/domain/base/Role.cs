using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace custom5
{
    public interface IRole
    {
    }

    public abstract class Role<TUser> : IRole 
        where TUser : IUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<TUser> Users { get; set; }
    }
}
