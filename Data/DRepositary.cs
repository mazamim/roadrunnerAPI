using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using roadrunnerapi.Models;

namespace roadrunnerapi.Data
{
    public class DRepositary : IDRepositary
    {
        private readonly DataContext _context;
          public DRepositary(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
                   _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
                 _context.Remove(entity);
        }

        public async Task<User> GetUser(int Id)
        {
         //var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == Id);
        var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == Id);
        return user;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}