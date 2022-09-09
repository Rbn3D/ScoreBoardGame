using NUnit.Framework;
using ScoreBoardLib.Logic;
using ScoreBoardLib.Model;
using System.Collections.Generic;

namespace ScoreBoardTest
{
    public class GameManagerTests
    {
        public GameManager GameManager { get; set; }

        [SetUp]
        public void Setup()
        {
            GameManager = new GameManager();
        }

        [Test]
        public void TestStartGame()
        {
            (Match game1, eGameOptionResult result1) = GameManager.StartMatch();

            Assert.NotNull(game1);
            Assert.AreEqual(result1, eGameOptionResult.Ok);

            (Match game2, eGameOptionResult result2) = GameManager.StartMatch();

            Assert.Null(game2);
            Assert.AreEqual(result2, eGameOptionResult.MatchAlreadyStarted);
        }

        [Test]
        public void TestFinishGame()
        {
            (Match game1, eGameOptionResult result1) = GameManager.FinishMatch();

            Assert.Null(game1);
            Assert.AreEqual(result1, eGameOptionResult.NoMatchToFinish);

            GameManager.StartMatch();

            (Match game2, eGameOptionResult result2) = GameManager.FinishMatch();

            Assert.NotNull(game2);
            Assert.AreEqual(result2, eGameOptionResult.Ok);

            (Match game3, eGameOptionResult result3) = GameManager.FinishMatch();

            Assert.Null(game3);
            Assert.AreEqual(result3, eGameOptionResult.NoMatchToFinish);
        }

        [Test]
        public void TestStoreGame()
        {
            eGameOptionResult result1 = GameManager.StoreFinishedMatch();

            Assert.AreEqual(result1, eGameOptionResult.NoMatchToStore);

            GameManager.StartMatch();
            (Match gameFinish, eGameOptionResult resultFinish) = GameManager.FinishMatch();

            eGameOptionResult result2 = GameManager.StoreFinishedMatch();

            Assert.AreEqual(result2, eGameOptionResult.Ok);

            List<Match> matches = GameManager.GetSummaryByTotalScore();

            Assert.AreEqual(matches.Count, 1);
            Assert.Contains(gameFinish, matches);
        }
    }
}