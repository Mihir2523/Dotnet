using System;
using System.Collections.Generic;

namespace Project.Models
{
    public class TimeTable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TimeTableName { get; set; }
        public List<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
    }

    public class TimeSlot
    {
         public Guid Id { get; set; } = Guid.NewGuid(); 
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public bool IsBreak {get;set;}
    }
}