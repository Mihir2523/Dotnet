using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTableController : ControllerBase
    {
        private readonly TimeTableDbContext _context;

        public TimeTableController(TimeTableDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
         var timeTables = _context.TimeTables
        .Include(t => t.TimeSlots)
        .ToList();
            return Ok(timeTables);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var timeTable = _context.TimeTables.Find(id);
            if (timeTable == null)
            {
                return NotFound();
            }
            return Ok(timeTable);
        }
    
        [HttpPost]
        public IActionResult Post([FromBody] TimeTable timeTable)
        {
            if (timeTable == null)
            {
                return BadRequest("TimeTable data is null.");
            }
            
            _context.TimeTables.Add(timeTable);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = timeTable.Id }, timeTable);
        }

        // [HttpPut("{id}")]
        // public IActionResult Put(Guid id, [FromBody] TimeTable updatedTimeTable)
        // {
        //     if (updatedTimeTable == null || id != updatedTimeTable.Id)
        //     {
        //         return BadRequest("Invalid data.");
        //     }

        //     var timeTable = _context.TimeTables.Find(id);
        //     if (timeTable == null)
        //     {
        //         return NotFound();
        //     }

        //     timeTable.TimeTableName = updatedTimeTable.TimeTableName;
        //     timeTable.TimeSlots = updatedTimeTable.TimeSlots;

        //     _context.SaveChanges();
        //     return NoContent();
        // }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var timeTable = _context.TimeTables.Find(id);
            if (timeTable == null)
            {
                return NotFound();
            }

            _context.TimeTables.Remove(timeTable);
            _context.SaveChanges();
            return NoContent();
        }

[HttpPut("{id}")]
public async Task<IActionResult> UpdateTimeTable(Guid id, [FromBody] TimeTable updatedTimeTable)
{
    var existingTimeTable = await _context.TimeTables
        .Include(t => t.TimeSlots)
        .FirstOrDefaultAsync(t => t.Id == id);

    if (existingTimeTable == null)
    {
        return NotFound();
    }

    // ❌ Instead of Remove(existingTimeTable), directly DELETE from DB
    var rowsDeleted = await _context.Database.ExecuteSqlRawAsync("DELETE FROM \"TimeTables\" WHERE \"Id\" = {0}", id);

    if (rowsDeleted == 0)
    {
        return NotFound();
    }

    // ✅ Create new timetable
    var newTimeTable = new TimeTable
    {
        Id = Guid.NewGuid(), // New ID
        TimeTableName = updatedTimeTable.TimeTableName,
        TimeSlots = updatedTimeTable.TimeSlots.Select(slot => new TimeSlot
        {
            Id = Guid.NewGuid(),
            StartTime = slot.StartTime,
            EndTime = slot.EndTime,
            Monday = slot.Monday,
            Tuesday = slot.Tuesday,
            Wednesday = slot.Wednesday,
            Thursday = slot.Thursday,
            Friday = slot.Friday,
            Saturday = slot.Saturday,
            IsBreak = slot.IsBreak
        }).ToList()
    };

    _context.TimeTables.Add(newTimeTable);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(Get), new { id = newTimeTable.Id }, newTimeTable);
}





    }
}