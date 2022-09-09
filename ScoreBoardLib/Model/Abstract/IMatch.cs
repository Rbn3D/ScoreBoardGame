namespace ScoreBoardLib.Model.Abstract
{
    public interface IMatch
    {
        string AwayTeam { get; set; }
        int AwayTeamScore { get; set; }
        string HomeTeam { get; set; }
        int HomeTeamScore { get; set; }
        int TotalScore { get; }
    }
}