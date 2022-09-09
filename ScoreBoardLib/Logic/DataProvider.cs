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
    public class DataProvider : IDataProvider
    {
        public IMatch GetNewMatch()
        {
            (string homeTeam, string awayTeam) = Teams.GetRandomTeamPair();

            return new Match(homeTeam, awayTeam);
        }

        public IMatch GetMatchResult(IMatch match)
        {
            (int homeScore, int awayScore) = GetRandomScore();

            match.HomeTeamScore = homeScore;
            match.AwayTeamScore = awayScore;

            return match;
        }

        private (int homeScore, int awayScore) GetRandomScore()
        {
            Random rnd = new Random();

            return (rnd.Next(6), rnd.Next(6));
        }
    }
}
