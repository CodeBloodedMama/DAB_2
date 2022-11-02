using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCore.data
{
    public class Context : DbContext
    {
        public DbSet<Facility> Facilities { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCore;Trusted_Connection=True;");
            optionsBuilder.UseInMemoryDatabase("FacilityDatabase");
        }
    }
    
}
