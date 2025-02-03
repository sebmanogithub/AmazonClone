using Amazon.Clone.Core.Entities;
using Amazon.Clone.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Clone.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users {get; set;}
    }
}