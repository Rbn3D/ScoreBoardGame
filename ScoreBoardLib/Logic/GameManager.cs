using ScoreBoardLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib.Logic
{
    public class GameManager
    {
        private Match StartedMatch { get; set; }
        private Match FinishedMatch { get; set; }

        private ScoreBoard ScoreBoard = new ScoreBoard();

        public (Match, eGameOptionResult) StartMatch()
        {
            if (StartedMatch == null)
            {
                (string homeTeam, string awayTeam) = Teams.GetRandomTeamPair();

                StartedMatch = new Match(homeTeam, awayTeam);

                return (StartedMatch, eGameOptionResult.Ok);
            }

            return (null, eGameOptionResult.MatchAlreadyStarted);
        }

        public (Match, eGameOptionResult) FinishMatch()
        {
            if (StartedMatch == null)
            {
                return (null, eGameOptionResult.NoMatchToFinish);
            }

            if(FinishedMatch != null)
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

        public List<Match> GetSummaryByTotalScore()
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
