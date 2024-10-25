namespace API_FlappyBirb.Models
{
    public class Score
    {

        public int Id { get; set; }

        public int Value { get; set; }

        public float Temps { get; set; }

        public DateTime Date { get; set; }

        public bool isVisible { get; set; }

        public virtual User? user { get; set; }

    }
}
