using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityDbManager.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? CVR { get; set; }
        public int? PhoneNumber { get; set; }

        //Navigationproperty that creates a one to many relationship in the database
        public ICollection<Reservation> Reservation { get; set; } = null!;


    }
}
