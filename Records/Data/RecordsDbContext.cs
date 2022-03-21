using Microsoft.EntityFrameworkCore;
using Records.Models;

namespace Records.Data
{
    public class RecordsDbContext : DbContext
    {
        public RecordsDbContext(DbContextOptions<RecordsDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
             
    }
}
