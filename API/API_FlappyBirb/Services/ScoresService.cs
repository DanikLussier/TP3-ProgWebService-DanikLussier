using API_FlappyBirb.Data;
using API_FlappyBirb.Models;
using Microsoft.EntityFrameworkCore;

namespace API_FlappyBirb.Services
{
    public class ScoresService
    {
        private readonly API_FlappyBirbContext _context;
        
        public ScoresService(API_FlappyBirbContext context)
        {
            _context = context;
        }

        public async Task<List<Score>> GetAll()
        {
            return await _context.Score.ToListAsync();
        }

        public async Task<Score> GetScore(int id)
        {
            return await _context.Score.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Score?> ChangeVisibility(int id, Score score)
        {
            if (IsScoresSetEmpty()) return null;

            score.isVisible = !score.isVisible;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ((await GetScore(id)) == null) return null;
                else throw;
            }

            return score;
        }

        public bool IsScoresSetEmpty()
        {
            return _context == null || _context.Score == null;
        }

        public async Task<Score?> CreateScore(Score score)
        {
            if (IsScoresSetEmpty()) return null;

            _context.Score.Add(score);
            await _context.SaveChangesAsync();

            return score;
        }
    }
}
