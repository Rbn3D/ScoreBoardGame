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
        private IScoreBoard ScoreBoard { get; set; }
        private IDataProvider DataProvider { get; set; }

        private IMatch StartedMatch { get; set; }
        private IMatch FinishedMatch { get; set; }

        public GameManager(IScoreBoard scoreBoard, IDataProvider dataProvider)
        {
            ScoreBoard = scoreBoard;
            DataProvider = dataProvider;
        }

        public (IMatch, eGameOptionResult) StartMatch()
        {
            if (StartedMatch == null)
            {
                StartedMatch = DataProvider.GetNewMatch();

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

            FinishedMatch = DataProvider.GetMatchResult(StartedMatch);
            StartedMatch = null;

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
    }
}
