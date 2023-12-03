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
        public async Task<ActionResult<IEnumerable<PlayerDetails>>> GetPlayers()
        {
            if(_dbContext.PlayerDetails == null)
            {
                return NotFound();
            }
            return await _dbContext.PlayerDetails.ToListAsync();
        }
    }
}
