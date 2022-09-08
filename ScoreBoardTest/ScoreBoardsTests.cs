using NUnit.Framework;
using ScoreBoardLib.Model;
using System.Collections.Generic;

namespace ScoreBoardTest
{
    public class ScoreBoardsTests
    {
        public ScoreBoard ScoreBoard { get; set; }

        [SetUp]
        public void Setup()
        {
            ScoreBoard = new ScoreBoard();
        }

        [Test]
        public void AssertNewItemsAreAdded()
        {
            ScoreBoard.RegisterMatch(new Match("SevillaFC", "BetisFC") { HomeTeamScore = 3, AwayTeamScore = 2 });
            Assert.AreEqual(ScoreBoard.MatchesSortedByTotalScore.Count, 1);

            ScoreBoard.RegisterMatch(new Match("Madrid", "Barcelona") { HomeTeamScore = 1, AwayTeamScore = 3 });
            Assert.AreEqual(ScoreBoard.MatchesSortedByTotalScore.Count, 2);

            ScoreBoard.RegisterMatch(new Match("MalagaFC", "Altetico") { HomeTeamScore = 2, AwayTeamScore = 4 });
            Assert.AreEqual(ScoreBoard.MatchesSortedByTotalScore.Count, 3);

            ScoreBoard.RegisterMatch(new Match("Juventus", "Madrid") { HomeTeamScore = 1, AwayTeamScore = 3 });
            Assert.AreEqual(ScoreBoard.MatchesSortedByTotalScore.Count, 4);

            ScoreBoard.RegisterMatch(new Match("Barcelona", "SevillaFC") { HomeTeamScore = 6, AwayTeamScore = 4 });
            Assert.AreEqual(ScoreBoard.MatchesSortedByTotalScore.Count, 5);
        }

        [Test]
        public void AssertOldItemsAreDeleted()
        {
            Match match1 = new Match("SevillaFC", "BetisFC") { HomeTeamScore = 3, AwayTeamScore = 2 };
            Match match2 = new Match("Madrid", "Barcelona") { HomeTeamScore = 1, AwayTeamScore = 3 };
            Match match3 = new Match("MalagaFC", "Altetico") { HomeTeamScore = 2, AwayTeamScore = 4 };

            Match match4 = new Match("Juventus", "Madrid") { HomeTeamScore = 1, AwayTeamScore = 3 };
            Match match5 = new Match("Barcelona", "SevillaFC") { HomeTeamScore = 6, AwayTeamScore = 4 };
            Match match6 = new Match("SevillaFC", "Madrid") { HomeTeamScore = 2, AwayTeamScore = 4 };
            Match match7 = new Match("Madrid", "MalagaFC") { HomeTeamScore = 3, AwayTeamScore = 5 };
            Match match8 = new Match("Altetico", "SevillaFc") { HomeTeamScore = 3, AwayTeamScore = 1 };

            ScoreBoard.RegisterMatch(match1);
            ScoreBoard.RegisterMatch(match2);
            ScoreBoard.RegisterMatch(match3);
            ScoreBoard.RegisterMatch(match4);
            ScoreBoard.RegisterMatch(match5);

            Assert.AreEqual(ScoreBoard.MatchesSortedByTotalScore.Count, 5);

            ScoreBoard.RegisterMatch(match6);
            ScoreBoard.RegisterMatch(match7);
            ScoreBoard.RegisterMatch(match8);

            Assert.AreEqual(ScoreBoard.MatchesSortedByTotalScore.Count, 5);

            List<Match> score = ScoreBoard.MatchesSortedByTotalScore;

            Assert.Contains(match4, score);
            Assert.Contains(match5, score);
            Assert.Contains(match6, score);
            Assert.Contains(match7, score);
            Assert.Contains(match8, score);

            Assert.IsFalse(score.Contains(match1));
            Assert.IsFalse(score.Contains(match2));
            Assert.IsFalse(score.Contains(match3));
        }

        [Test]
        public void AssertOrderByTotalScore()
        {
            ScoreBoard.RegisterMatch(new Match("SevillaFC", "BetisFC") { HomeTeamScore = 8, AwayTeamScore = 8 });   // 16
            ScoreBoard.RegisterMatch(new Match("MalagaFC", "Altetico") { HomeTeamScore = 1, AwayTeamScore = 1 });   // 2
            ScoreBoard.RegisterMatch(new Match("Juventus", "Madrid") { HomeTeamScore = 4, AwayTeamScore = 4 });     // 8
            ScoreBoard.RegisterMatch(new Match("Barcelona", "SevillaFC") { HomeTeamScore = 6, AwayTeamScore = 6 }); // 12

            List<Match> sortedScore = ScoreBoard.MatchesSortedByTotalScore;

            Assert.AreEqual(sortedScore[0].TotalScore, 16);
            Assert.AreEqual(sortedScore[1].TotalScore, 12);
            Assert.AreEqual(sortedScore[2].TotalScore, 8);
            Assert.AreEqual(sortedScore[3].TotalScore, 2);
        }
    }
}