using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Route("/api/user/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserAuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            if (_context.AppUsers.Any(u => u.Email == model.Email))
                return Conflict("Email already exists");

            var user = new AppUser
            {
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
                Role = model.Role
            };

            _context.AppUsers.Add(user);
            _context.SaveChanges();

            return Ok(new { user.Email, user.Name, user.Role });
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _context.AppUsers.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null || user.Password != dto.Password)
                return Unauthorized("Invalid credentials");

            return Ok(new { user.Email, user.Name, user.Role });
        }

        [HttpGet("All")]
        public IActionResult GetAll(){
            var users = _context.AppUsers.ToList();
            if(users == null){
                return NotFound();
            }
            return Ok(users);
        }
    }
}