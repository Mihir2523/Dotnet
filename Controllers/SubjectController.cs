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
    public class SubjectController : ControllerBase
    {
        private readonly TimeTableDbContext _context;

        public SubjectController(TimeTableDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var subjects = _context.Subjects.ToList();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SubjectDto subject)
        {
            if (subject == null)
            {
                return BadRequest("Subject data is null.");
            
            }
            Subject subjectt;
            if(subject.HasLab){
                subjectt = new Subject{
                Name = subject.Name,
                Class = subject.Class,
                HoursPerWeek = subject.HoursPerWeek,
                SubjectCode = subject.SubjectCode,
                HasLab = subject.HasLab,
                LabId = subject.LabId
            };    
            }else{
            subjectt = new Subject{
                Name = subject.Name,
                Class = subject.Class,
                HoursPerWeek = subject.HoursPerWeek,
                SubjectCode = subject.SubjectCode,
                HasLab = subject.HasLab
            };
            }
            _context.Subjects.Add(subjectt);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = subjectt.Id }, subjectt);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Subject updatedSubject)
        {
            if (updatedSubject == null || id != updatedSubject.Id)
            {
                return BadRequest("Invalid data.");
            }

            var subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            subject.Name = updatedSubject.Name;
            subject.Class = updatedSubject.Class;
            subject.HoursPerWeek = updatedSubject.HoursPerWeek;
            subject.SubjectCode = updatedSubject.SubjectCode;
            subject.HasLab = updatedSubject.HasLab;
            subject.LabId = updatedSubject.LabId;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Subject/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return NoContent();
        }
    }
}