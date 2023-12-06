using EvidentaMasini.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EvidentaMasini.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CombustionType>? combustionTypes { get; set; }
        public DbSet<Car>? cars { get; set; }
        public DbSet<user>? users { get; set; }
    }
}