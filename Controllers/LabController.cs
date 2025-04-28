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
    public class LabController : ControllerBase
    {
        private readonly TimeTableDbContext _context;

        public LabController(TimeTableDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var labs = _context.Labs.ToList();
            return Ok(labs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var lab = _context.Labs.Find(id);
            if (lab == null)
            {
                return NotFound();
            }
            return Ok(lab);
        }

        [HttpPost]
        public IActionResult Post([FromBody] LabDto lab)
        {
            if (lab == null)
            {
                return BadRequest("Lab data is null.");
            }
            Lab labs = new Lab{
                Name = lab.Name,
                Class = lab.Class,
                Branch = lab.Branch,
                TimeSlot = lab.TimeSlot,

            };
            _context.Labs.Add(labs);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = labs.Id }, labs);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Lab updatedLab)
        {
            if (updatedLab == null || id != updatedLab.Id)
            {
                return BadRequest("Invalid data.");
            }

            var lab = _context.Labs.Find(id);
            if (lab == null)
            {
                return NotFound();
            }
            lab.Class = updatedLab.Class;
            lab.Branch = updatedLab.Branch;
            lab.TimeSlot = updatedLab.TimeSlot;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var lab = _context.Labs.Find(id);
            if (lab == null)
            {
                return NotFound();
            }

            _context.Labs.Remove(lab);
            _context.SaveChanges();
            return NoContent();
        }
    }
}