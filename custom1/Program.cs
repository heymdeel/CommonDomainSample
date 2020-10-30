using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using domain;
using System.Threading.Tasks;

namespace custom1
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

            var customUser = new CustomUser()
            {
                Login = "test_custom",
                Email = "test@test",
                Role = baseRole,
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

                var customUsersWithBaseRolesFilter = await db
                    .Set<CustomUser>()
                    .Include(x => x.Role)
                    .Where(x => x.Role.Name == "admin")
                    .ToListAsync();

                var baseRolesWithBaseUsers = await db.Set<Role>().Include(r => r.Users).ToListAsync();

                Console.WriteLine("test");
            }
        }

        private static async Task TestHandler()
        {
            var baseRole = new Role()
            {
                Name = "admin_handler"
            };

            var baseUser = new User()
            {
                Login = "test_handler",
                Email = "test@test_handler",
                Role = baseRole
            };

            var customUser = new CustomUser()
            {
                Login = "test_custom_handler",
                Email = "test@test_handler",
                Region = "NY_handler"
            };

            var handler = new BaseHandler();

            var savedBasedUser = await handler.SaveUser(baseUser);
            customUser.RoleId = baseRole.Id;
            var savedCustomUser = await handler.SaveUser(customUser);

            var baseRoleField = await handler.GetRoleField(baseUser);
            var customRoleField = await handler.GetRoleField(customUser);

            var login = await handler.GetUserLogin(baseRole);

            Console.WriteLine("test");
        }
    }
}
