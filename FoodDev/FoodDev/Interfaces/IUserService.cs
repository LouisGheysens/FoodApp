using System.Threading.Tasks;

namespace FoodDev.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExists(string uname);
        Task<bool> LoginUser(string uname, string passwd);
        Task<bool> RegisterUser(string uname, string passwd);
    }
}