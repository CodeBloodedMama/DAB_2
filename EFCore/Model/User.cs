using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class User
    {
<<<<<<< Updated upstream
        public int Id { get; set; }

=======
        public int Id { get; set; } = default!;
>>>>>>> Stashed changes
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CVR { get; set; }
        public int PhoneNumber { get; set; }
        public List<Reservation> Reservations { get; set; } = new();

    }
}
