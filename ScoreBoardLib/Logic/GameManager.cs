using ScoreBoardLib.Logic.Abstract;
using ScoreBoardLib.Model;
using ScoreBoardLib.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib.Logic
{
    public class GameManager : IGameManager
    {
        private IMatch StartedMatch { get; set; }
        private IMatch FinishedMatch { get; set; }

        private IScoreBoard ScoreBoard { get; set; }

        public GameManager(IScoreBoard scoreBoard)
        {
            ScoreBoard = scoreBoard;
        }

        public (IMatch, eGameOptionResult) StartMatch()
        {
            if (StartedMatch == null)
            {
                (string homeTeam, string awayTeam) = Teams.GetRandomTeamPair();

                StartedMatch = new Match(homeTeam, awayTeam);

                return (StartedMatch, eGameOptionResult.Ok);
            }

            return (null, eGameOptionResult.MatchAlreadyStarted);
        }

        public (IMatch, eGameOptionResult) FinishMatch()
        {
            if (StartedMatch == null)
            {
                return (null, eGameOptionResult.NoMatchToFinish);
            }

            if (FinishedMatch != null)
            {
                return (null, eGameOptionResult.MatchFinishedButNotStored);
            }

            (int homeScore, int awayScore) = GetRandomScore();

            FinishedMatch = StartedMatch;
            StartedMatch = null;

            FinishedMatch.HomeTeamScore = homeScore;
            FinishedMatch.AwayTeamScore = awayScore;

            return (FinishedMatch, eGameOptionResult.Ok);
        }

        public eGameOptionResult StoreFinishedMatch()
        {
            if (FinishedMatch == null)
                return eGameOptionResult.NoMatchToStore;

            ScoreBoard.RegisterMatch(FinishedMatch);
            FinishedMatch = null;

            return eGameOptionResult.Ok;
        }

        public List<IMatch> GetSummaryByTotalScore()
        {
            return ScoreBoard.MatchesSortedByTotalScore;
        }

        private (int homeScore, int awayScore) GetRandomScore()
        {
            Random rnd = new Random();

            return (rnd.Next(6), rnd.Next(6));
        }
    }
}
