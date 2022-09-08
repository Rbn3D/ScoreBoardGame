using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib.Model
{
    public class Match
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int HomeTeamScore { get; set; } = 0;
        public int AwayTeamScore { get; set; } = 0;

        public int TotalScore => HomeTeamScore + AwayTeamScore;

        public Match(string homeTeam, string awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public override string ToString()
        {
            return $"{HomeTeam} - {AwayTeam}: {HomeTeamScore} - {AwayTeamScore}";
        }
    }
}
