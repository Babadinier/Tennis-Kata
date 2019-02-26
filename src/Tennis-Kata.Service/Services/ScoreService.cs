namespace Tennis_Kata.Service
{
    public class ScoreService
    {
        public ScoreService()
        {

        }

        public Score WinPoint(Score _score, Player player)
        {
            if(player == _score.Server)
            {
                UpdateScore(_score.Server, _score.Receiver);
            }
            else
            {
                UpdateScore(_score.Receiver, _score.Server);
            }
            return _score;
        }

        private void UpdateScore(Player playerWinPoint, Player playerLosePoint)
        {
            if (playerWinPoint.ScoreEnum == ScoreEnum.Fourty)
            {
                if (playerLosePoint.ScoreEnum == ScoreEnum.Fourty)
                {
                    playerWinPoint.ScoreEnum = UpScoreEnum(playerWinPoint.ScoreEnum);
                }
                else if (playerLosePoint.ScoreEnum == ScoreEnum.Advantage)
                {
                    playerLosePoint.ScoreEnum = ScoreEnum.Fourty;
                }
                else
                {
                    playerWinPoint.ScoreEnum = ScoreEnum.GameWin;
                }
            }
            else if (playerWinPoint.ScoreEnum == ScoreEnum.Advantage)
            {
                playerWinPoint.ScoreEnum = ScoreEnum.GameWin;
            }
            else
            {
                playerWinPoint.ScoreEnum = UpScoreEnum(playerWinPoint.ScoreEnum);
            }
        }

        private ScoreEnum UpScoreEnum(ScoreEnum scoreEnum)
        {
            switch (scoreEnum)
            {
                case ScoreEnum.Zero:
                    return ScoreEnum.Fifteen;
                case ScoreEnum.Fifteen:
                    return ScoreEnum.Thirty;
                case ScoreEnum.Thirty:
                    return ScoreEnum.Fourty;
                case ScoreEnum.Fourty:
                    return ScoreEnum.Advantage;
            }

            return ScoreEnum.Zero;
        }
    }
}
