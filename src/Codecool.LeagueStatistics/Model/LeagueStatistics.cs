using System;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.LeagueStatistics.Model
{
    /// <summary>
    ///     Provides all necessary statistics of played season.
    /// </summary>
    public static class LeagueStatistics
    {
        /// <summary>
        ///     Gets all teams with highests points order, if points are equal next deciding parameter is sum of golas of the team.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static IEnumerable<Team> GetAllTeamsSorted(this IEnumerable<Team> teams)
            => teams.OrderByDescending(a => a.CurrentPoints)
                .ThenByDescending(team => team.Players.Sum(x => x.Goals));

        /// <summary>
        ///     Gets all players from each team in one collection.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static IEnumerable<Player> GetAllPlayers(this IEnumerable<Team> teams)
            => teams.SelectMany(x => x.Players);

        /// <summary>
        ///     Gets team with the longest name
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static Team GetTeamWithTheLongestName(this IEnumerable<Team> teams)
            => teams.OrderByDescending(team => team.Name.Length).First();

        /// <summary>
        ///     Gets top teams with least number of lost matches.
        ///     If the amount of lost matches is equal, next deciding parameter is team's current points value.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="teamsNumber">The number of Teams to select.</param>
        /// <returns>Collection of selected Teams.</returns>
        public static IEnumerable<Team> GetTopTeamsWithLeastLoses(this IEnumerable<Team> teams, int teamsNumber)
            => teams.OrderBy(team => team.Losts).ThenByDescending(team => team.CurrentPoints).Take(teamsNumber);

        /// <summary>
        ///     Gets a player with the biggest goals number from each team.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static IEnumerable<Player> GetTopPlayersFromEachTeam(this IEnumerable<Team> teams)
            => teams.Select(team => team.Players.OrderByDescending(player => player.Goals).First());

        /// <summary>
        ///     Returns the division with greatest amount of points.
        ///     If there is more than one division with the same amount current points, then check the amounts of wins.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static Division GetStrongestDivision(this IEnumerable<Team> teams)
            => teams.OrderByDescending(team => team.CurrentPoints).ThenByDescending(team => team.Wins).Select(team => team.Division).First();

        /// <summary>
        ///     Gests all teams, where there are players with no scored goals.
        /// </summary>
        /// <param name="teams"></param>
        /// <returns></returns>
        public static IEnumerable<Team> GetTeamsWithPlayersWithoutGoals(this IEnumerable<Team> teams)
            => teams.Where(team => team.Players.Any(player => player.Goals == 0));

        /// <summary>
        /// Gets players with given or higher number of goals scored.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="goals">The minimal number of golas scored.</param>
        /// <returns>Collection of Players with given or higher number of goals scored.</returns>
        public static IEnumerable<Player> GetPlayersWithAtLeastXGoals(this IEnumerable<Team> teams, int goals)
            => teams.SelectMany(team => team.Players.Where(player => player.Goals >= goals));

        /// <summary>
        ///     Gets the player with the highest skill rate for given Division.
        /// </summary>
        /// <param name="teams"></param>
        /// <param name="division"></param>
        /// <returns></returns>
        public static Player GetMostTalentedPlayerInDivision(this IEnumerable<Team> teams, Division division)
            => teams.Where(team => team.Division == division).SelectMany(team => team.Players)
                .OrderByDescending(player => player.SkillRate).First();

    }
}
