using ChessAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly ChessContext _dbContext;

        public EnrollController(ChessContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Data/students
        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        // GET: api/Data/students/5
        [HttpGet("students/{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // POST: api/Data/students
        [HttpPost("students")]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            // Check if a student with the same name and parent email already exists
            if (await _dbContext.Students.AnyAsync(s =>
                s.Name == student.Name &&
                s.ParentEmail == student.ParentEmail))
            {
                return BadRequest("A student with the same name and parent email already exists.");
            }

            student.StudentID = 0;
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.StudentID }, student);
        }

        // DELETE: api/Data/students/5
        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/Data/professionals
        [HttpGet("professionals")]
        public async Task<ActionResult<IEnumerable<Professional>>> GetProfessionals()
        {
            return await _dbContext.Professionals.ToListAsync();
        }

        // GET: api/Data/professionals/5
        [HttpGet("professionals/{id}")]
        public async Task<ActionResult<Professional>> GetProfessional(int id)
        {
            var professional = await _dbContext.Professionals.FindAsync(id);

            if (professional == null)
            {
                return NotFound();
            }

            return professional;
        }

        // POST: api/Data/professionals
        [HttpPost("professionals")]
        public async Task<ActionResult<Professional>> PostProfessional(Professional professional)
        {
            // Check if same name and email already exists
            if (await _dbContext.Professionals.AnyAsync(s =>
                s.Name == professional.Name &&
                s.Email == professional.Email))
            {
                return BadRequest("A professional with the same name and email already exists.");
            }

            professional.ProfessionalID = 0;
            _dbContext.Professionals.Add(professional);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfessional), new { id = professional.ProfessionalID }, professional);
        }

        // DELETE: api/Data/professionals/5
        [HttpDelete("professionals/{id}")]
        public async Task<IActionResult> DeleteProfessional(int id)
        {
            var professional = await _dbContext.Professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }

            _dbContext.Professionals.Remove(professional);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
