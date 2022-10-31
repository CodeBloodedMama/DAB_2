using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityDbManager.Model
{
    public class Facility
    {
        public int Fac_Id { get; set; }
        public string Fac_Name { get; set; } = null!;

        public string Fac_ClosestAdr { get; set; } = null!;

        public string Fac_Type { get; set; } = null!;

        public string Fac_Rules { get; set; } = null!;

        public string Fac_Items { get; set; } = null!;
        


    }
}
