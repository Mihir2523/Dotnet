using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Teacher
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<Guid> SubjectIds { get; set; } = new List<Guid>(); 
        public List<TimeSpan> AvailableTimeSlots { get; set; } = new List<TimeSpan>(); 
 
    }
    public class TeacherDto
    {
        public string Name { get; set; }
        public List<Guid> SubjectIds { get; set; } = new List<Guid>(); 
        public List<TimeSpan> AvailableTimeSlots { get; set; } = new List<TimeSpan>(); 
    }
}