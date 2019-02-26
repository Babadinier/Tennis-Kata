namespace Tennis_Kata.Service
{
    public class Player
    {
        public ScoreEnum ScoreEnum { get; set; }

        public Player(ScoreEnum scoreEnum)
        {
            ScoreEnum = scoreEnum;
        }
    }
}