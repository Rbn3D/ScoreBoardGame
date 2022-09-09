using ScoreBoardLib.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib.Model
{
    public class ScoreBoard : IScoreBoard
    {
        private const int MAX_MATCHES = 5;

        private List<IMatch> Matches { get; set; } = new List<IMatch>();

        public List<IMatch> MatchesSortedByTotalScore
        {
            get
            {
                return Matches.OrderByDescending(m => m.TotalScore).ToList();
            }
        }

        public void RegisterMatch(IMatch match)
        {
            Matches.Add(match);

            if (Matches.Count > MAX_MATCHES)
                Matches.RemoveAt(0);
        }
    }
}
