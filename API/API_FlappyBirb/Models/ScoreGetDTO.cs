namespace API_FlappyBirb.Models
{
    public class ScoreGetDTO
    {
        public int Id { get; set; }

        public int ScoreValue { get; set; }

        public float TimeInSeconds { get; set; }

        public DateTime Date { get; set; }

        public bool IsPublic { get; set; }

        public string Pseudo { get; set; } = null!;
    }
}
