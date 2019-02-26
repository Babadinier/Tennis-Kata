namespace Tennis_Kata.Service
{
    public class Score
    {
        public Player Server { get; }
        public Player Receiver { get; }

        public Score(Player server, Player receiver)
        {
            Server = server;
            Receiver  = receiver;
        }

        public override string ToString()
        {
            return $"Player1: {Server.ScoreEnum} - Player2: {Receiver .ScoreEnum}";
        }
    }
}
