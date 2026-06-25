using Crudoperationfirst25.Models;
using Microsoft.EntityFrameworkCore;

namespace Crudoperationfirst25
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Usersabc { get; set; }

    }
}
