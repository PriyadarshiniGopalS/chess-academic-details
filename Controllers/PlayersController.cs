using ChessAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChessApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ChessContext _dbContext;

        public PlayersController(ChessContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollDetails>>> GetPlayers()
        {
            if (_dbContext.EnrollDetails == null)
            {
                return NotFound();
            }
            return await _dbContext.EnrollDetails.ToListAsync();
        }

        [HttpPost]
        [Route("EnrollPlayer")]
        public async Task<ActionResult<EnrollDetails>> EnrollPlayer(EnrollDetails enrollDetails)
        {
            _dbContext.EnrollDetails.Add(enrollDetails);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlayers), new { id = enrollDetails.EmailID }, enrollDetails);
        }
    }
}
