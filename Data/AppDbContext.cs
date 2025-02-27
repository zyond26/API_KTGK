using Microsoft.EntityFrameworkCore;
using GoodsAPI.Models;

namespace GoodsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<HangHoa> Goods { get; set; }
    }
}
