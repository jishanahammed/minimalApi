using mfminimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mfminimalApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
