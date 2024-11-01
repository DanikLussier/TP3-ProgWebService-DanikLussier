using System.ComponentModel.DataAnnotations;

namespace API_FlappyBirb.Models
{
    public class ScorePostDTO
    {
        [Required]
        public int Value { get; set; }
        [Required]
        public float Time { get; set; }
    }
}
