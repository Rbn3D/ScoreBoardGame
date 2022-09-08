using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib.Model
{
    public class ScoreBoard
    {
        private const int MAX_MATCHES = 5;

        private List<Match> Matches { get; set; } = new List<Match>();

        public List<Match> MatchesSortedByTotalScore
        {
            get
            {
                return Matches.OrderByDescending(m => m.TotalScore).ToList();
            }
        }

        public void RegisterMatch(Match match)
        {
            Matches.Add(match);

            if (Matches.Count > MAX_MATCHES)
                Matches.RemoveAt(0);
        }
    }
}
