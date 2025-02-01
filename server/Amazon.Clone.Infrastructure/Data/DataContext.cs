using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task SeedTestData()
        {
            if (!Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser { UserName = "Bob" },
                    new AppUser { UserName = "Marie" },
                    new AppUser { UserName = "John" },
                };

                var firstUser = users[0];
                var secondUser = users[1];
                typeof(BaseEntity).GetProperty("CreatedAt")
                    ?.SetValue(firstUser, DateTime.UtcNow.AddDays(-10));
                typeof(BaseEntity).GetProperty("UpdatedAt")
                    ?.SetValue(firstUser, DateTime.UtcNow.AddDays(-1));

                typeof(BaseEntity).GetProperty("CreatedAt")
                    ?.SetValue(secondUser, DateTime.UtcNow.AddDays(-23));
                typeof(BaseEntity).GetProperty("UpdatedAt")
                    ?.SetValue(secondUser, DateTime.UtcNow.AddDays(-12));

                await Users.AddRangeAsync(users);
                await SaveChangesAsync();
            }
        }
    }
}