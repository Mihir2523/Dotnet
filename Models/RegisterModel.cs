using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class RegisterModel
    {
        public string Name { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}