using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace custom5
{
    public class BaseHandler<TUser, TRole, TTest> : IBaseHandler<TUser, TRole, TTest>
        where TUser : User<TTest, TRole>
        where TRole : Role<TUser>
        where TTest: Test<TUser>
    {
        public async Task<TUser> SaveUser(TUser user)
        {
            using (var db = new Context())
            {
                db.Set<TUser>().Add(user);

                await db.SaveChangesAsync();
            }

            return user;
        }

        public virtual async Task<string> GetRoleField(TUser user)
        {
            using (var db = new Context())
            {
                var dbUser = await db.Set<TUser>().Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == user.Id);

                return dbUser.Role.Name;
            }
        }

        public async Task<string> GetUserLogin(TRole role)
        {
            using (var db = new Context())
            {
                var dbRole = await db.Set<TRole>().Include(u => u.Users).FirstOrDefaultAsync(r => r.Id == role.Id);

                return role.Users.First().Login;
            }
        }
    }
}
