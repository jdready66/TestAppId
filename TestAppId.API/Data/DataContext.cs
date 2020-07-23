using Microsoft.EntityFrameworkCore;
using TestAppId.API.Models;

namespace TestAppId.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Value> Values { get; set; }
        public DataContext(DbContextOptions opts) : base(opts) {}
    }
}