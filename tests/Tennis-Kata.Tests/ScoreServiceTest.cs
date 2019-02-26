using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tennis_Kata.Service;

namespace Tennis_Kata.Tests
{
    [TestClass]
    public class ScoreServiceTest
    {
        private readonly ScoreService _scoreService;
        public ScoreServiceTest()
        {
            _scoreService = new ScoreService();
            
        }

        [TestMethod]
        public void should_return_initialize_score_game()
        {
            var _score = new Score(new Player(ScoreEnum.Zero), new Player(ScoreEnum.Zero));
            Assert.AreEqual(ScoreEnum.Zero, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.Zero, _score.Receiver .ScoreEnum);
        }

        [TestMethod]
        public void should_return_score_equals_to_15_0_when_server_wins_point()
        {
            var _score = new Score(new Player(ScoreEnum.Zero), new Player(ScoreEnum.Zero));

            var new_score = _scoreService.WinPoint(_score, _score.Server);

            Assert.AreEqual(ScoreEnum.Fifteen, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.Zero, _score.Receiver.ScoreEnum);
        }

        [TestMethod]
        public void should_return_score_equals_to_15_30_when_receveir_wins_point()
        {
            var _score = new Score(new Player(ScoreEnum.Fifteen), new Player(ScoreEnum.Fifteen));

            var new_score = _scoreService.WinPoint(_score, _score.Receiver);

            Assert.AreEqual(ScoreEnum.Fifteen, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.Thirty, _score.Receiver.ScoreEnum);
        }

        [TestMethod]
        public void should_return_score_equals_to_40_30_when_server_wins_point()
        {
            var _score = new Score(new Player(ScoreEnum.Thirty), new Player(ScoreEnum.Thirty));

            var new_score = _scoreService.WinPoint(_score, _score.Server);

            Assert.AreEqual(ScoreEnum.Fourty, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.Thirty, _score.Receiver.ScoreEnum);
        }

        [TestMethod]
        public void should_return_score_equals_to_40_A_when_receiver_wins_point()
        {
            var _score = new Score(new Player(ScoreEnum.Fourty), new Player(ScoreEnum.Fourty));

            var new_score = _scoreService.WinPoint(_score, _score.Receiver);

            Assert.AreEqual(ScoreEnum.Fourty, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.Advantage, _score.Receiver.ScoreEnum);
        }

        [TestMethod]
        public void should_return_score_equals_to_40_40_when_score_is_A_40_and_receiver_wins_new_point()
        {
            var _score = new Score(new Player(ScoreEnum.Advantage), new Player(ScoreEnum.Fourty));

            var new_score = _scoreService.WinPoint(_score, _score.Receiver);

            Assert.AreEqual(ScoreEnum.Fourty, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.Fourty, _score.Receiver.ScoreEnum);
        }

        [TestMethod]
        public void should_return_gamewin_server_when_score_is_40_30_and_server_wins_new_point()
        {
            var _score = new Score(new Player(ScoreEnum.Fourty), new Player(ScoreEnum.Thirty));

            var new_score = _scoreService.WinPoint(_score, _score.Server);

            Assert.AreEqual(ScoreEnum.GameWin, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.Thirty, _score.Receiver.ScoreEnum);
        }

        [TestMethod]
        public void should_return_gamewin_receiver_when_score_is_40_A_and_receiver_wins_new_point()
        {
            var _score = new Score(new Player(ScoreEnum.Fourty), new Player(ScoreEnum.Advantage));

            var new_score = _scoreService.WinPoint(_score, _score.Receiver);

            Assert.AreEqual(ScoreEnum.Fourty, _score.Server.ScoreEnum);
            Assert.AreEqual(ScoreEnum.GameWin, _score.Receiver.ScoreEnum);
        }
    }
}
