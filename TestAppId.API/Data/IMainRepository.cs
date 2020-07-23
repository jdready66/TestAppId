using System.Threading.Tasks;
using TestAppId.API.Models;

namespace TestAppId.API.Data
{
    public interface IMainRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<Value> GetValue(int id);
    }


}