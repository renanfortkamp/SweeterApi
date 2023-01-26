using Microsoft.EntityFrameworkCore;
using Sweeter.Models.Entities;

namespace Sweeter.Context
{
    public class SweeterContext : DbContext
    {
        public SweeterContext(DbContextOptions<SweeterContext> options) : base(options){

        }

        public DbSet<User> users { get; set; }
        public DbSet<Sweet> sweets { get; set; }
    }
}
