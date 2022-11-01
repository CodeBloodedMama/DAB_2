using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityDbManager.Model
{
    public class Facility
    {

        // Entity Framework requires a primary key that is automatically generated within 
        // the database. The [Key] attribute is used to identify the primary key.
        // Id is the primary key
        public int Id { get; set; }
        public string Fac_Name { get; set; } = null!;

        public string Fac_ClosestAdr { get; set; } = null!;

        public string Fac_Type { get; set; } = null!;

        public string Fac_Rules { get; set; } = null!;

        public string Fac_Items { get; set; } = null!;

       
        





    }
}
