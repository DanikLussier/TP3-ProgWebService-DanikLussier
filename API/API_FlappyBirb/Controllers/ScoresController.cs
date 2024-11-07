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
using API_FlappyBirb.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;

namespace API_FlappyBirb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ScoresController : ControllerBase
    {
        private readonly ScoresService _scoresService;
        readonly UserManager<User> UserManager;

        public ScoresController(ScoresService scoresService, UserManager<User> userManager)
        {
            _scoresService = scoresService;
            UserManager = userManager;
        }

        // GET: api/Scores
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Score>>> GetPublicScores()
        {
            IEnumerable<Score> scores = await _scoresService.GetAll();

            return Ok(scores.Where(s => s.user != null && s.isVisible == true).OrderByDescending(s => s.Value).Take(10).Select(s => new ScoreGetDTO
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
            User? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return Unauthorized(); //non authentifié ou token invalide

            if (_scoresService.IsScoresSetEmpty()) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "Veuillez réessayer plus tard" }); //Prob avec la BD?

            return Ok(user.Scores.Select(s => new ScoreGetDTO
            {
                Id = s.Id,
                ScoreValue = s.Value,
                TimeInSeconds = s.Temps,
                Date = s.Date,
                IsPublic = s.isVisible,
                Pseudo = s.user!.UserName
            }));
        }

        // POST: api/Score
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(ScorePostDTO dto)
        {
            User? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (user == null) return Unauthorized(); // Non authentifié ou token invalide

            var score = new Score
            {
                Value = dto.Value,
                Temps = dto.Time,
                Date = DateTime.Now,
                isVisible = false,
                user = user
            };
            Score? newScore = await _scoresService.CreateScore(score);

            if (newScore == null) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "Veuillez réessayer plus tard." }); //Prob avec la BD?

            return Ok(newScore);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Score>> ChangeScoreVisibility(int id)
        {
            //Utilisateur qui fait la requête
            User? user = await UserManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            //Score à supprimer
            var score = await _scoresService.GetScore(id);

            //Si le commentaire n'est pas trouvé
            if (score == null) return NotFound();

            //Si l'utilisateur n'est PAS propriétaire du commentaire
            if (user == null || score.user != user)
            {
                return Unauthorized(new { Message = "Hey touche pas, c'est pas à toi !" });
            }

            Score? newScore = await _scoresService.ChangeVisibility(id, score);

            if (newScore == null) return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "Veuillez réessayer plus tard." }); // Prob avec la BD?

            return Ok(new { Message = "Visibilité modifiée", Score = score });
        }
    }
}
