using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityDbManager.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
 
        // virtual creates a one to one or one to zero relation
        public virtual User User { get; set; } = null!;
        public virtual Facility Facility { get; set; } = null!;

    }
}
