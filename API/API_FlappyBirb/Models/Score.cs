using System.Text.Json.Serialization;

namespace API_FlappyBirb.Models
{
    public class Score
    {

        public int Id { get; set; }

        public int Value { get; set; }

        public float Temps { get; set; }

        public DateTime Date { get; set; }

        public bool isVisible { get; set; }

        [JsonIgnore]
        public virtual User? user { get; set; }

        public Score(int score, float time)
        {
            Temps = time;
            Value = score;
        }

        public Score()
        {

        }
    }
}
