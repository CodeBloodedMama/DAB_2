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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=FacilityDbManager;Trusted_Connection=True;");
        }
    }
    
}
