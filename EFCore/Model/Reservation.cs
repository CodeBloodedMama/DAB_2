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
        public int UserId { get; set; }
        public int Fac_Id { get; }
        public User User { get; set; } = null!;
        public Facility Facility { get; set; } = null!;

        public ICollection<ReservationDetails> ReservationDetails { get; set; } = null!;
        

    }
}
