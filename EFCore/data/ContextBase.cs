using EFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore.data
{
    public abstract class ContextBase
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Facility> Facility { get; set; } = null!;
        public DbSet<Reservation> Reservation { get; set; } = null!;

        protected abstract override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}