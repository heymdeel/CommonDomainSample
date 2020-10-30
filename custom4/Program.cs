using domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace custom4
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await TestContext();

            await TestHandler();
        }

        private static async Task TestContext()
        {
            var baseRole = new Role()
            {
                Name = "admin"
            };

            var baseUser = new User()
            {
                Login = "test",
                Email = "test@test",
                Role = baseRole
            };

            var customRole = new CustomRole()
            {
                CustomField = 1,
                Name = "custom_admin"
            };

            var customUser = new CustomUser()
            {
                Login = "test_custom",
                Email = "test@test",
                CustomRole = customRole,
                Region = "NY"
            };

            using (var db = new Context())
            {
                db.Set<User>().Add(baseUser);
                db.Set<CustomUser>().Add(customUser);

                db.SaveChanges();

                var baseUsersWithBaseRoles = await db
                    .Set<User>()
                    .Include(x => x.Role)
                    .ToListAsync();

                var customUsersWithCustomRolesFilter = await db
                    .Set<CustomUser>()
                    .Include(x => x.CustomRole)
                    .Where(x => x.CustomRole.CustomField == 2)
                    .ToListAsync();

                var customUsersWithBaseRolesFilter = await db
                    .Set<CustomUser>()
                    .Include(x => x.CustomRole)
                    .Where(x => x.CustomRole.CustomField == 2)
                    .ToListAsync();

                var baseRolesWithBaseUsers = await db.Set<Role>().Include(r => r.Users).ToListAsync();
                var customRolesWithCustomUsers = await db.Set<CustomRole>().Include(r => r.CustomUsers).ToListAsync();
                var customRolesBaseUsers = await db.Set<CustomRole>().Include(r => r.Users).ToListAsync();

                Console.WriteLine("test");
            }
        }

        private static async Task TestHandler()
        {
            var baseRole = new Role()
            {
                Name = "admin"
            };

            var baseUser = new User()
            {
                Login = "test",
                Email = "test@test_handler",
                Role = baseRole
            };

            var customRole = new CustomRole()
            {
                CustomField = 1,
                Name = "custom_admin_handler"
            };

            var customUser = new CustomUser()
            {
                Login = "test_custom_handler",
                Email = "test@test_handler",
                CustomRole = customRole,
                Region = "NY"
            };

            var handler = new BaseHandler();

            var savedBaseUser = await handler.SaveUser(baseUser);
            var savedCustomUser = await handler.SaveUser(customUser);

            var baseRoleField = await handler.GetRoleField(baseUser);
            var customRoleField = await handler.GetRoleField(customUser);

            var baseLogin = await handler.GetUserLogin(baseRole);
            var customLogin = await handler.GetUserLogin(customRole);

            Console.WriteLine("test");
        }
    }
}
