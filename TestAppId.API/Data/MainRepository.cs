using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAppId.API.Models;

namespace TestAppId.API.Data
{
    public class MainRepository : IMainRepository
    {
        private readonly DataContext _context;
        public MainRepository(DataContext context)
        {            _context = context;        }
        public void Add<T>(T entity) where T : class
        {            _context.Add(entity);        }
        public void Delete<T>(T entity) where T : class
        {            _context.Remove(entity);        }
        public async Task<bool> SaveAll()
        {            return await _context.SaveChangesAsync() > 0;        }
        public async Task<Value> GetValue(int id)
        {
            return await _context.Values.Where(v => v.Id == id).FirstOrDefaultAsync();
        }
    }

}