using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly TimeTableDbContext _context;

        public TeacherController(TimeTableDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _context.Teachers.ToList();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TeacherDto teacher)
        {
            if (teacher == null)
            {
                return BadRequest("Teacher data is null.");
            }
            Teacher teacherr = new Teacher{
                Name = teacher.Name,
                SubjectIds = teacher.SubjectIds,
                AvailableTimeSlots = teacher.AvailableTimeSlots,
            };
            _context.Teachers.Add(teacherr);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = teacherr.Id }, teacherr);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Teacher updatedTeacher)
        {
            if (updatedTeacher == null || id != updatedTeacher.Id)
            {
                return BadRequest("Invalid data.");
            }

            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            teacher.Name = updatedTeacher.Name;
            teacher.SubjectIds = updatedTeacher.SubjectIds;
            teacher.AvailableTimeSlots = updatedTeacher.AvailableTimeSlots;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return NoContent();
        }
    }
}