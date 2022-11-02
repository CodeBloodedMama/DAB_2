using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCore.data
{
    public class Context : DbContext
    {
        public DbSet<Facility> Facilities { get; set; } = default!;
        public DbSet<Reservation> Reservations { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        private const string MarcinConnString =
            "Data Source=127.0.0.1,1433;Database=FacilitiesDb;User Id=sa;Password=MyDumbPass1;TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(MarcinConnString);
            //optionsBuilder.UseInMemoryDatabase("FacilityDatabase");
        }
    }
    
}
