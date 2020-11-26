using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace custom5
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
            //var baseRole = new Role()
            //{
            //    Name = "admin"
            //};

            //var baseUser = new User()
            //{
            //    Login = "test",
            //    Email = "test@test",
            //    Role = baseRole
            //};

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
                // ##########| Exception |####################
                //db.Set<User>().Add(baseUser);
                db.Set<CustomUser>().Add(customUser);

                db.SaveChanges();

                // ##########| Exception |####################
                //var baseUsersWithBaseRoles = await db
                //    .Set<User>()
                //    .Include(x => x.Role)
                //    .ToListAsync();

                var customUsersWithCustomRolesFilter = await db
                    .Set<CustomUser>()
                    .Include(x => x.Role)
                    .Where(x => x.Role.CustomField == 2)
                    .ToListAsync();

                // ##########| Exception |####################
                //var baseRolesWithBaseUsers = await db.Set<Role>().Include(r => r.Users).ToListAsync();
                var customRolesWithCustomUsers = await db.Set<CustomRole>().Include(r => r.Users).ToListAsync();

                Console.WriteLine("test");
            }
        }

        private static async Task TestHandler()
        {
            //var baseRole = new Role()
            //{
            //    Name = "admin"
            //};

            //var baseUser = new User()
            //{
            //    Login = "test",
            //    Email = "test@test_handler",
            //    Role = baseRole
            //};

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

            var handler = new BaseHandler<CustomUser, CustomRole, CustomTest>();

            // ##########| Exception |####################
            //var savedBaseUser = await handler.SaveUser(baseUser);
            var savedCustomUser = await handler.SaveUser(customUser);

            // ##########| Exception |####################
            //var baseRoleField = await handler.GetRoleField(baseUser);
            var customRoleField = await handler.GetRoleField(customUser);

            // ##########| Exception |####################
            //var baseLogin = await handler.GetUserLogin(baseRole);
            var customLogin = await handler.GetUserLogin(customRole);

            Console.WriteLine("test");
        }
    }
}
