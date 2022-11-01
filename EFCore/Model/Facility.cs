using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityDbManager.Model
{
    public class Facility
    {
        [Key]
        // Entity Framework requires a primary key that is automatically generated within 
        // the database. The [Key] attribute is used to identify the primary key.
        public int Id { get; set; }
        public string Fac_Name { get; set; } = null!;

        public string Fac_ClosestAdr { get; set; } = null!;

        public string Fac_Type { get; set; } = null!;

        public string Fac_Rules { get; set; } = null!;

        public string Fac_Items { get; set; } = null!;

        public virtual ICollection<Reservation> Reservations { get; set; } = null!;

        public virtual ICollection<User> User { get; set; } = null!;







    }
}
