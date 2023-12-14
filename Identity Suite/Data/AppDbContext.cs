using Identity_Suite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_Suite.Data
{
    public class AppDbContext : IdentityDbContext
    { 
        public AppDbContext(DbContextOptions options) : base (options)
        {
        }

        // Models
        public DbSet<AppUser> AppUsers { get; set; }

    }

}
