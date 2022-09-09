using ScoreBoardLib.Model;
using ScoreBoardLib.Model.Abstract;
using System.Collections.Generic;

namespace ScoreBoardLib.Logic.Abstract
{
    public interface IGameManager
    {
        (IMatch, eGameOptionResult) StartMatch();
        (IMatch, eGameOptionResult) FinishMatch();
        eGameOptionResult StoreFinishedMatch();
        List<IMatch> GetSummaryByTotalScore();
    }
}