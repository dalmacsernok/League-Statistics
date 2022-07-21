using Codecool.LeagueStatistics.Controllers;
using Codecool.LeagueStatistics.View;

namespace Codecool.LeagueStatistics
{
    public static class Program
    {
        public static void Main()
        {
            Season season = new Season();
            season.Run();
            Display.LeagueResult(Model.LeagueStatistics.GetAllTeamsSorted(season.League));
        }
    }
}
