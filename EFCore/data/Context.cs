using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacilityDbManager.Model;
using Microsoft.EntityFrameworkCore;


namespace FacilityDbManager.data
{
    public class Context : DbContext
    {
        //Each DbTabel will be matched to its database
        public DbSet<Facility> Facilities { get; set; } = null!;
        

        public DbSet<Reservation> Reservations { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;


        //Connectionstring has to be dockerized.
        //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FacilityDbManager;Trusted_Connection=True;");
        }
    }
    
}
