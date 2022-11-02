using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class User
    {
        public int Id { get; set; } = default!;

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CVR { get; set; }

        public int PhoneNumber { get; set; }
        

    }
}
