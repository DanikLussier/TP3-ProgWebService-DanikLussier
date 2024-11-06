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
using NuGet.Protocol.Plugins;

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

            return Ok(scores.Where(s => s.user != null && s.isVisible == true).Select(s => new ScoreGetDTO
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
            if (_context.Score == null) return NotFound();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User? user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                IEnumerable<Score> scores = await _context.Score.ToListAsync();

                return Ok(scores.Where(s => s.user == user).Select(s => new ScoreGetDTO
                {
                    Id = s.Id,
                    ScoreValue = s.Value,
                    TimeInSeconds = s.Temps,
                    Date = s.Date,
                    IsPublic = s.isVisible,
                    Pseudo = s.user!.UserName
                }));
            }

            return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Utilisateur non trouvé." });
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Score>> ChangeScoreVisibility(int id)
        {
            //Utilisateur qui fait la requête
            User? user = await _context.Users.FindAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (_context.Score == null) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "Veuillez réessayer plus tard." }); // Problème BD?

            //Score à supprimer
            var score = await _context.Score.Where(s => s.Id == id).FirstOrDefaultAsync();

            //Si le commentaire n'est pas trouvé
            if (score == null) return NotFound();

            //Si l'utilisateur n'est PAS propriétaire du commentaire
            if (user == null || !user.Scores.Contains(score))
            {
                return Unauthorized(new { Message = "Hey touche pas, c'est pas à toi !" });
            }

            score.isVisible = !score.isVisible;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if ((await _context.Score.FindAsync(id)) == null) return NotFound();
                else throw;
            }

            return Ok(new { Message = "Visibilité modifiée", Score = score });
        }
    }
}
