using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Subject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Class { get; set; }
        public int HoursPerWeek { get; set; }
        public string SubjectCode { get; set; }
        public bool HasLab { get; set; } = false;
        public Guid? LabId { get; set; }
    }
    public class SubjectDto
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int HoursPerWeek { get; set; }
        public string SubjectCode { get; set; }
        public bool HasLab { get; set; } = false;
        public Guid? LabId { get; set; }
    }
}