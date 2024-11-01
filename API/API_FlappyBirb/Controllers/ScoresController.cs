using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_FlappyBirb.Data;
using API_FlappyBirb.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace API_FlappyBirb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ScoresController : ControllerBase
    {
        private readonly API_FlappyBirbContext _context;

        public ScoresController(API_FlappyBirbContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
            IEnumerable<Score> scores = await _context.Score.ToListAsync();

            return Ok(scores.Where(s => s.user != null).Select(s => new ScoreGetDTO
            {
                Id = s.Id,
                ScoreValue = s.Value,
                TimeInSeconds = s.Temps,
                Date = s.Date,
                IsPublic = s.isVisible,
                Pseudo = s.user!.UserName
            }));
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> GetMyScores()
        {
            return await _context.Score.ToListAsync();
        }

        // POST: api/Score
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(ScorePostDTO dto)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                var newScore = new Score(dto.Value, dto.Time)
                {
                    Date = DateTime.Now,
                    isVisible = true,
                    user = user
                };

                _context.Score.Add(newScore);
                await _context.SaveChangesAsync();

                return Ok(newScore);
            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Utilisateur non trouvé" });
        }

        [HttpPut]
        public async Task<ActionResult<Score>> ChangeScoreVisibility()
        {
            return Ok();
        }
    }
}
