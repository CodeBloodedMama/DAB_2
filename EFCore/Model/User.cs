using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CVR { get; set; }

        public int PhoneNumber { get; set; }
        

    }
}
