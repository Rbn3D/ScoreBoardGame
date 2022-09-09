using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreBoardLib.Model
{
    public enum eGameOptionResult
    {
        Ok = 1,
        MatchAlreadyStarted,
        MatchFinishedButNotStored,
        NoMatchToFinish,
        NoMatchToStore
    }
}
