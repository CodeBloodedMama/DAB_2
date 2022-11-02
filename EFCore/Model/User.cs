using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class User
    {
        [Key]
        [Required]
        public long CPRNumber { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CVR { get; set; }
        public int PhoneNumber { get; set; }
        public List<Reservation> Reservations { get; set; } = new();

    }
}
