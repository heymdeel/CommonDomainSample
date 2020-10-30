using domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace custom2
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
                Role = customRole,
                Region = "NY"
            };

            using (var db = new Context())
            {
                db.Set<User>().Add(baseUser);
                // ##########| Exception |####################
                //db.Set<CustomUser>().Add(customUser);

                db.SaveChanges();

                var baseUsersWithBaseRoles = await db
                    .Set<User>()
                    .Include(x => x.Role)
                    .ToListAsync();

                // ##########| Exception |####################
                //var customUsersWithCustomRolesFilter = await db 
                //    .Set<CustomUser>()
                //    .Include(x => x.Role)
                //    .Where(x => x.Role.CustomField == 2)
                //    .ToListAsync();

                var baseRolesWithBaseUsers = await db.Set<Role>().Include(r => r.Users).ToListAsync();
                var customRolesBaseUsers = await db.Set<CustomRole>().Include(r => r.Users).ToListAsync();

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

            var customRole = new CustomRole()
            {
                CustomField = 1,
                Name = "custom_admin_handler"
            };

            var customUser = new CustomUser()
            {
                Login = "test_custom_handler",
                Email = "test@test_handler",
                Role = customRole,
                Region = "NY"
            };

            var handler = new BaseHandler();

            var savedBaseUser = await handler.SaveUser(baseUser);
            
            // ##########| Exception |####################
            //customUser.RoleId = customRole.Id;

            customUser.RoleId = baseRole.Id;
            var savedCustomUser = await handler.SaveUser(customUser);

            //var baseRoleField = await handler.GetRoleField(baseUser);
            var customRoleField = await handler.GetRoleField(customUser);

            //var baseLogin = await handler.GetUserLogin(baseRole);
            var customLogin = await handler.GetUserLogin(customRole);

            Console.WriteLine("test");
        }
    }
}
