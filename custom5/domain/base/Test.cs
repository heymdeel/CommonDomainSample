using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace custom5
{
    public interface ITest
    {
    }

    public abstract class Test<TUser> : ITest
        where TUser : IUser
    {
        public int Id { get; set; }

        public string TestField { get; set; }

        public IEnumerable<TUser> Users { get; set; }
    }
}
