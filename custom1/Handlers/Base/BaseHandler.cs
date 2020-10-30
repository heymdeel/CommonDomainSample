using domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom1
{
    public class BaseHandler : IBaseHandler
    {
        public async Task<User> SaveUser(User user)
        {
            using (var db = new Context())
            {
                db.Set<User>().Add(user);

                await db.SaveChangesAsync();
            }

            return user;
        }

        public async Task<string> GetRoleField(User user)
        {
            using (var db = new Context())
            {
                var dbUser = await db.Set<User>().Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == user.Id);

                return dbUser.Role.Name;
            }
        }

        public async Task<string> GetUserLogin(Role role)
        {
            using (var db = new Context())
            {
                var dbRole = await db.Set<Role>().Include(u => u.Users).FirstOrDefaultAsync(r => r.Id == role.Id);

                return role.Users.First().Login;
            }
        }
    }
}
