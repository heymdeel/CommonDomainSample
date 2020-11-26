using System.Threading.Tasks;

namespace custom5
{
    public interface IBaseHandler<TUser, TRole, TTest>
        where TUser : User<TTest, TRole>
        where TRole : Role<TUser>
        where TTest : Test<TUser>
    {
        Task<TUser> SaveUser(TUser user);

        Task<string> GetRoleField(TUser user);

        Task<string> GetUserLogin(TRole role);

    }
}
