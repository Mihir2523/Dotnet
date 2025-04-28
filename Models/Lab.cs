using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Lab
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Class { get; set; }
        public string Branch { get; set; }
        public string Name { get; set; }
        public TimeSpan TimeSlot { get; set; }
    }
    public class LabDto
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Branch { get; set; }
        public TimeSpan TimeSlot { get; set; }
    }
}
