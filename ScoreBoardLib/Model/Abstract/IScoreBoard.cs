using System.Collections.Generic;

namespace ScoreBoardLib.Model.Abstract
{
    public interface IScoreBoard
    {
        List<IMatch> MatchesSortedByTotalScore { get; }

        void RegisterMatch(IMatch match);
    }
}