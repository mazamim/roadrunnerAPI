using System.Threading.Tasks;
using roadrunnerapi.Models;

namespace roadrunnerapi.Data
{
    public interface IDRepositary
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<User> GetUser(int Id);
    }
}