using CourseRegister.Data;
using CourseRegister.DTO;
using CourseRegister.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
     
        private readonly RegisterDbContext _context;

        public RegisterController(RegisterDbContext context)
        {
            _context = context;
        }

        // API 1: Get existing courses
        [HttpGet("courses")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _context.Courses
                .Select(c => new
                {
                    c.CourseId,
                    c.CourseName
                })
                .ToListAsync();

            return Ok(courses);
        }


        // API 2: Save manually entered student details

         [HttpPost("register")]
        public async Task<IActionResult> RegisterStudent(
            [FromBody] RegistrationRequest request)
        {
            // Check whether course exists
            var courseExists = await _context.Courses
                .AnyAsync(c => c.CourseId == request.CourseId);

            if (!courseExists)
            {
                return BadRequest(new
                {
                    message = "Invalid Course Selection"
                });
            }
            var register = new Register
            {
                name = request.StudentName,
                email = request.Email,
                mobile = request.Phone,
                CourseId = request.CourseId
            };
            _context.Registrations.Add(register);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Student Registered Successfully",
                registerId = register.RegisterId
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistration(int id)
        {
            var registration = await _context.Registrations
                .Include(r => r.Course)
                .Where(r => r.RegisterId == id)
                .Select(r => new
                {
                    r.RegisterId,
                    r.name,
                    r.email,
                    r.mobile,
                    r.CourseId,
                    CourseName = r.Course!.CourseName
                })
                 .FirstOrDefaultAsync();

            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);

        }
}
}
