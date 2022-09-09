using ScoreBoardLib.Model.Abstract;

namespace ScoreBoardLib.Logic.Abstract
{
    public interface IDataProvider
    {
        IMatch GetMatchResult(IMatch match);
        IMatch GetNewMatch();
    }
}