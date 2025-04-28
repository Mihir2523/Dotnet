using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Models;
namespace Project.Data
{
    public class TimeTableDbContext : DbContext
    {
     
       public TimeTableDbContext(DbContextOptions<TimeTableDbContext> options) : base(options) { 

       }

 protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TimeTable>()
            .HasMany(t => t.TimeSlots)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade); 
    }
    
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lab> Labs { get; set; }
         public DbSet<TimeSlot> TimeSlots { get; set; }
        
    }
}