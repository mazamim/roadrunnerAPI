
using System.Threading.Tasks;
using roadrunnerapi.Models;

namespace mywep.API.Data
{
    public interface IAuthRepository
    {
  
         Task <User> Register(User user, string Password);

         Task<User> Login(string Username, string Password);

         Task<bool> UserExist(string UserName);
    }
}