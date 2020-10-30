using domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace custom1
{
    public interface IBaseHandler
    {
        Task<User> SaveUser(User user);

        Task<string> GetRoleField(User user);

        Task<string> GetUserLogin(Role role);
    }
}
